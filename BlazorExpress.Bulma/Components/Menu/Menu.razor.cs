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
            await JSRuntime.InvokeVoidAsync(MenuJsInterop.Initialize, Id, objRef);

            var width = await JSRuntime.InvokeAsync<float>(MenuJsInterop.WindowSize);

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
    [AddedVersion("1.2.0")]
    [Description("Toggles the menu visibility.")]
    public void Toggle()
    {
        IsVisible = !IsVisible;
        _ = InvokeAsync(StateHasChanged);
    }

    [JSInvokable]
    public void WindowResizeJS(float width)
    {
        deviceType = width.ToDeviceTypeEnum();
        IsVisible = deviceType != DeviceType.Mobile;

        _ = InvokeAsync(StateHasChanged);
    }

    internal void HideMenu()
    {
        if (deviceType == DeviceType.Mobile)
        {
            IsVisible = false;
            _ = InvokeAsync(StateHasChanged);
        }
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
    [AddedVersion("1.2.0")]
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
    [AddedVersion("1.2.0")]
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
    [AddedVersion("1.2.0")]
    [DefaultValue(true)]
    [Description("If <b>true</b>, the menu is visible.")]
    [Parameter]
    public bool IsVisible { get; set; } = true;

    #endregion
}
