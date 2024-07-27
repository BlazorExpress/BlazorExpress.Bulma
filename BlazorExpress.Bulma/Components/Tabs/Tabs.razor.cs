namespace BlazorExpress.Bulma;

/// <summary>
/// <see href="https://bulma.io/documentation/components/tabs/" />
/// </summary>
public partial class Tabs : BulmaComponentBase
{
    #region Fields and Constants

    private Tab activeTab = default!;

    private Tab previousActiveTab = default!;

    private bool isDefaultActiveTabSet = false;

    private List<Tab>? tabs = new();

    #endregion

    #region Methods

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender && !isDefaultActiveTabSet)
            SetDefaultActiveTab();

        base.OnAfterRender(firstRender);
    }

    internal void AddTab(Tab tab)
    {
        tabs!.Add(tab);

        if (tab is { IsActive: true, IsDisabled: false })
            activeTab = tab;

        StateHasChanged(); // This is mandatory
    }

    /// <summary>
    /// Sets default active tab.
    /// </summary>
    internal void SetDefaultActiveTab()
    {
        if (!tabs?.Any() ?? true) return;

        activeTab ??= tabs!.FirstOrDefault(x => !x.IsDisabled)!;

        if (activeTab is not null)
            activeTab.Show();

        isDefaultActiveTabSet = true;
    }

    private void ShowTab(Tab currentTab)
    {
        if (currentTab?.IsDisabled ?? true) return;

        previousActiveTab = activeTab;
        activeTab = currentTab;

        // hide the previous active tab
        foreach (Tab tab in tabs!)
        {
            if (tab.IsActive)
            {
                tab.Hide();

                if (OnHidden.HasDelegate)
                    OnHidden.InvokeAsync(new TabEventArgs(tab));
            }
        }

        // show the new tab
        foreach (Tab tab in tabs!)
        {
            if (tab.Id == currentTab.Id)
            {
                tab.Show();

                if (OnShown.HasDelegate)
                    OnShown.InvokeAsync(new TabEventArgs(tab));

                continue;
            }
        }

        if (OnTabChanged.HasDelegate)
            OnTabChanged.InvokeAsync(new TabsEventArgs(activeTab, previousActiveTab));
    }

    /// <summary>
    /// Gets the active tab.
    /// </summary>
    /// <returns>
    /// Returns the cuurent active <see cref="Tab"/>.
    /// </returns>
    public Tab GetActiveTab() => activeTab;

    /// <summary>
    /// Removes the tab by index.
    /// </summary>
    /// <param name="tabIndex"></param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    public void RemoveTabByIndex(int tabIndex)
    {
        if (!tabs?.Any() ?? true) return;

        if (tabIndex < 0 || tabIndex >= tabs!.Count) throw new IndexOutOfRangeException();

        var tab = tabs[tabIndex];

        if (tab is null) return;

        tabs!.Remove(tab);
    }

    /// <summary>
    /// Removes the tab by name.
    /// </summary>
    /// <param name="tabName"></param>
    public void RemoveTabByName(string tabName)
    {
        if (!tabs?.Any() ?? true) return;

        var tabIndex = tabs!.FindIndex(x => x.Name == tabName);

        if (tabIndex == -1) return;

        var tab = tabs[tabIndex];

        tabs!.Remove(tab);
    }

    /// <summary>
    /// Selects the first tab and show its associated pane.
    /// </summary>
    public void ShowFirstTabAsync()
    {
        if (!tabs?.Any() ?? true) return;

        var tab = tabs!.FirstOrDefault(x => !x.IsDisabled);

        ShowTab(tab!);
    }

    /// <summary>
    /// Selects the last tab and show its associated pane.
    /// </summary>
    public void ShowLastTab()
    {
        if (!tabs?.Any() ?? true) return;

        var tab = tabs!.LastOrDefault(x => !x.IsDisabled);

        ShowTab(tab!);
    }

    /// <summary>
    /// Selects the tab by index and show its associated pane.
    /// </summary>
    /// <param name="tabIndex">The zero-based index of the element to get or set.</param>
    public void ShowTabByIndex(int tabIndex)
    {
        if (!tabs?.Any() ?? true) return;

        if (tabIndex < 0 || tabIndex >= tabs!.Count) throw new IndexOutOfRangeException();

        var tab = tabs[tabIndex];

        ShowTab(tab);
    }

    /// <summary>
    /// Selects the tab by name and show its associated pane.
    /// </summary>
    /// <param name="tabName">The name of the tab to select.</param>
    public void ShowTabByName(string tabName)
    {
        if (!tabs?.Any() ?? true) return;

        var tabIndex = tabs!.FindIndex(x => x.Name == tabName);

        if (tabIndex == -1) return;

        var tab = tabs[tabIndex];

        ShowTab(tab);
    }

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(
            Class,
            (BulmaCssClass.Tabs, true),
            (Alignment.ToTabsAlignmentClass(), Alignment != TabsAlignment.None),
            (Size.ToTabsSizeClass(), Size != TabsSize.None),
            (Type.ToTabsTypeClass(), Type != TabsType.None),
            (BulmaCssClass.IsFullWidth, IsFullWidth));

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> alignment.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="TabsAlignment.None" />.
    /// </remarks>
    [Parameter]
    public TabsAlignment Alignment { get; set; }

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> width.
    /// If <see langword="true"/>, tabs will take up the whole width available.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool IsFullWidth { get; set; }

    /// <summary>
    /// This event fires after a new tab is shown (and thus the previous active tab is hidden).
    /// </summary>
    [Parameter]
    public EventCallback<TabEventArgs> OnHidden { get; set; }

    /// <summary>
    /// This event fires on tab show after a tab has been shown.
    /// </summary>
    [Parameter]
    public EventCallback<TabEventArgs> OnShown { get; set; }

    /// <summary>
    /// This event fires when the user clicks the corresponding tab and the tab is displayed.
    /// </summary>
    [Parameter]
    public EventCallback<TabsEventArgs> OnTabChanged { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> size.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="TabsSize.None" />.
    /// </remarks>
    [Parameter]
    public TabsSize Size { get; set; }

    /// <summary>
    /// Gets or sets the tabs container CSS class.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public string? TabsContainerCssClass { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="TabsType.None" />.
    /// </remarks>
    [Parameter]
    public TabsType Type { get; set; }

    #endregion
}
