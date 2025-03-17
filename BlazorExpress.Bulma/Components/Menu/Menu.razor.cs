namespace BlazorExpress.Bulma;

/// <summary>
/// Menu component
/// <para>
///     <see href="https://bulma.io/documentation/components/menu/" />
/// </para>
/// </summary>
public partial class Menu : BulmaComponentBase
{
    #region Fields and Constants

    private DeviceType deviceType;

    private DotNetObjectReference<Menu> objRef = default!;

    #endregion

    #region Methods

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync(MenuInterop.Initialize, Id, objRef);

            var width = await JSRuntime.InvokeAsync<float>(MenuInterop.WindowSize);

            WindowResizeJS(width);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    protected override async Task OnInitializedAsync()
    {
        objRef ??= DotNetObjectReference.Create(this);

        await base.OnInitializedAsync();
    }

    /// <summary>
    /// Toggles the menu.
    /// </summary>
    /// <returns>
    /// Current menu visible state.
    /// <see langword="true" /> if the menu is visible, <see langword="false" /> if it is hidden.
    /// </returns>
    public void Toggle()
    {
        IsVisible = !IsVisible;
    }

    [JSInvokable]
    public void WindowResizeJS(float width)
    {
        deviceType = width.ToDeviceTypeEnum();
        IsVisible = deviceType != DeviceType.Mobile;

        StateHasChanged();
    }

    internal void HideMenu()
    {
        if (deviceType == DeviceType.Mobile)
            IsVisible = false;

        //StateHasChanged();
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Menu, true),
            (BulmaCssClass.IsScrollable, IsScrollable),
            (BulmaCssClass.P5, true),
            (BulmaCssClass.IsHidden, !IsVisible)
        );

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// If <see langword="true" />, the menu is scrollable.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the menu is scrollable.")]
    [Parameter]
    public bool IsScrollable { get; set; } = false;

    /// <summary>
    /// If <see langword="true" />, the menu is visible.
    /// <para>
    /// Default value is <see langword="true" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(true)]
    [Description("If <b>true</b>, the menu is visible.")]
    [Parameter]
    public bool IsVisible { get; set; } = true;

    #endregion
}
