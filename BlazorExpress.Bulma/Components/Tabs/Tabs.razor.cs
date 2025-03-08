namespace BlazorExpress.Bulma;

/// <summary>
/// Tabs component
/// <see href="https://bulma.io/documentation/components/tabs/" />
/// </summary>
public partial class Tabs : BulmaComponentBase
{
    #region Fields and Constants

    private Tab activeTab = default!;

    private bool isDefaultActiveTabSet = false;

    private Tab previousActiveTab = default!;

    private List<Tab>? tabs = new();

    #endregion

    #region Methods

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender && !isDefaultActiveTabSet)
            SetDefaultActiveTab();

        base.OnAfterRender(firstRender);
    }

    /// <summary>
    /// Gets the active tab.
    /// </summary>
    /// <returns>
    /// Returns the current active <see cref="Tab" />.
    /// </returns>
    [AddedVersion("1.0.0")]
    [Description("Gets the active tab.")]
    public Tab GetActiveTab() => activeTab;

    /// <summary>
    /// Removes the tab by index.
    /// </summary>
    /// <param name="tabIndex"></param>
    /// <exception cref="IndexOutOfRangeException"></exception>
    [AddedVersion("1.0.0")]
    [Description("Removes the tab by index.")]
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
    [AddedVersion("1.0.0")]
    [Description("Removes the tab by name.")]
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
    [AddedVersion("1.0.0")]
    [Description("Selects the first tab and show its associated pane.")]
    public void ShowFirstTab()
    {
        if (!tabs?.Any() ?? true) return;

        var tab = tabs!.FirstOrDefault(x => !x.IsDisabled);

        ShowTab(tab!);
    }

    /// <summary>
    /// Selects the last tab and show its associated pane.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Selects the last tab and show its associated pane.")]
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
    [AddedVersion("1.0.0")]
    [Description("Selects the tab by index and show its associated pane.")]
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
    [AddedVersion("1.0.0")]
    [Description("Selects the tab by name and show its associated pane.")]
    public void ShowTabByName(string tabName)
    {
        if (!tabs?.Any() ?? true) return;

        var tabIndex = tabs!.FindIndex(x => x.Name == tabName);

        if (tabIndex == -1) return;

        var tab = tabs[tabIndex];

        ShowTab(tab);
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

        StateHasChanged();
    }

    private void ShowTab(Tab currentTab)
    {
        if (currentTab?.IsDisabled ?? true) return;

        previousActiveTab = activeTab;
        activeTab = currentTab;

        // hide the previous active tab
        foreach (var tab in tabs!)
            if (tab.IsActive)
            {
                tab.Hide();

                if (OnHidden.HasDelegate)
                    OnHidden.InvokeAsync(new TabEventArgs(tab));
            }

        // show the new tab
        foreach (var tab in tabs!)
            if (tab.Id == currentTab.Id)
            {
                tab.Show();

                if (OnShown.HasDelegate)
                    OnShown.InvokeAsync(new TabEventArgs(tab));
            }

        if (OnTabChanged.HasDelegate)
            OnTabChanged.InvokeAsync(new TabsEventArgs(activeTab, previousActiveTab));
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Tabs, true),
            ("mb-0", true),
            (Alignment.ToTabsAlignmentClass(), Alignment != TabsAlignment.None),
            (Size.ToTabsSizeClass(), Size != TabsSize.None),
            (Type.ToTabsTypeClass(), Type != TabsType.None),
            (BulmaCssClass.IsFullWidth, IsFullWidth)
        );

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> alignment.
    /// <para>
    /// Default value is <see cref="TabsAlignment.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(TabsAlignment.None)]
    [Description("Gets or sets the <code>Tabs</code> alignment.")]
    [Parameter]
    public TabsAlignment Alignment { get; set; } = TabsAlignment.None;

    /// <summary>
    /// Gets or sets the child content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// If <see langword="true" />, tabs will take up the whole width available.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the <code>Tabs</code> width. If <b>true</b>, tabs will take up the whole width available.")]
    [Parameter]
    public bool IsFullWidth { get; set; } = false;

    /// <summary>
    /// This event fires after a new tab is shown (and thus the previous active tab is hidden).
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires after a new tab is shown (and thus the previous active tab is hidden).")]
    [Parameter]
    public EventCallback<TabEventArgs> OnHidden { get; set; }

    /// <summary>
    /// This event fires on tab show after a tab has been shown.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires on tab show after a tab has been shown.")]
    [Parameter]
    public EventCallback<TabEventArgs> OnShown { get; set; }

    /// <summary>
    /// This event fires when the user clicks the corresponding tab and the tab is displayed.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the user clicks the corresponding tab and the tab is displayed.")]
    [Parameter]
    public EventCallback<TabsEventArgs> OnTabChanged { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> size.
    /// <para>
    /// Default value is <see cref="TabsSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(TabsSize.None)]
    [Description("Gets or sets the <code>Tabs</code> size.")]
    [Parameter]
    public TabsSize Size { get; set; } = TabsSize.None;

    /// <summary>
    /// Gets or sets the tabs container CSS class.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the tabs container CSS class.")]
    [Parameter]
    public string? TabsContainerCssClass { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> type.
    /// <para>
    /// Default value is <see cref="TabsType.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(TabsType.None)]
    [Description("Gets or sets the <code>Tabs</code> type.")]
    [Parameter]
    public TabsType Type { get; set; } = TabsType.None;

    #endregion
}
