namespace BlazorExpress.Bulma;

/// <summary>
/// <see href="https://bulma.io/documentation/components/menu/" />
/// </summary>
public partial class Menu : BulmaComponentBase
{
    #region Fields and Constants

    //private bool collapseNavMenu = true;

    private bool isVisible = false;

    private DeviceType deviceType;

    private DotNetObjectReference<Menu> objRef = default!;

    private bool requestInProgress = false;

    #endregion

    #region Methods

    protected override async Task OnInitializedAsync()
    {
        objRef ??= DotNetObjectReference.Create(this);

        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync(MenuInterop.Initialize, Id, objRef);

            var width = await JSRuntime.InvokeAsync<float>(MenuInterop.WindowSize);

            await WindowResizeJS(width);
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    [JSInvokable]
    public async Task WindowResizeJS(float width)
    {
        deviceType = width.ToDeviceTypeEnum();
        isVisible = (deviceType != DeviceType.Mobile);

        StateHasChanged();

        if (OnWindowResize.HasDelegate)
            await OnWindowResize.InvokeAsync(new WindowResizeEventArgs(width, deviceType));
    }

    /// <summary>
    /// Toggles menu.
    /// </summary>
    public bool Toggle()
    {
        isVisible = !isVisible;
        return isVisible;
    }

    //internal void HideNavMenuOnMobile()
    //{
    //    if (isMobile && !collapseNavMenu)
    //        collapseNavMenu = true;
    //}

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(
            Class,
            (BulmaCssClass.Menu, true),
            (BulmaCssClass.P5, true),
            ("is-hidden", !isVisible));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EventCallback<WindowResizeEventArgs> OnWindowResize { get; set; }

    #endregion
}
