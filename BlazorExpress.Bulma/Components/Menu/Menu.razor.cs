namespace BlazorExpress.Bulma;

/// <summary>
/// <see href="https://bulma.io/documentation/components/menu/" />
/// </summary>
public partial class Menu : BulmaComponentBase
{
    #region Fields and Constants

    private bool isVisible = false;

    private DeviceType deviceType;

    private float width;

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

        if (OnStateChanged.HasDelegate)
            await OnStateChanged.InvokeAsync(isVisible);

        if (OnWindowResize.HasDelegate)
            await OnWindowResize.InvokeAsync(new WindowResizeEventArgs(deviceType, width));
    }

    /// <summary>
    /// Toggles the menu.
    /// </summary>
    /// <returns>
    /// Current menu visible state.
    /// <see langword="true"/> if the menu is visible, <see langword="false"/> if it is hidden.
    /// </returns>
    public Task Toggle()
    {
        isVisible = !isVisible;

        if (OnStateChanged.HasDelegate)
            return OnStateChanged.InvokeAsync(isVisible);

        return Task.CompletedTask;
    }

    internal Task HideMenu()
    {
        if (deviceType == DeviceType.Mobile)
        {
            isVisible = false;

            if (OnStateChanged.HasDelegate)
                return OnStateChanged.InvokeAsync(isVisible);

            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(
            Class,
            (BulmaCssClass.Menu, true),
            ("is-scrollable", IsScrollable),
            (BulmaCssClass.P5, true),
            (BulmaCssClass.IsHidden, !isVisible));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool IsScrollable { get; set; }

    [Parameter]
    public EventCallback<WindowResizeEventArgs> OnWindowResize { get; set; }

    [Parameter]
    public EventCallback<bool> OnStateChanged { get; set; }

    #endregion
}
