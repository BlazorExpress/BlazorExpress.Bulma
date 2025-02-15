namespace BlazorExpress.Bulma;

/// <summary>
/// Menu component
/// <see href="https://bulma.io/documentation/components/menu/" />
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

    protected override string? CssClassNames =>
        CssUtility.BuildClassNames(
            Class,
            (BulmaCssClass.Menu, true),
            (BulmaCssClass.IsScrollable, IsScrollable),
            (BulmaCssClass.P5, true),
            (BulmaCssClass.IsHidden, !IsVisible)
        );

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter] public bool IsScrollable { get; set; }

    [Parameter] public bool IsVisible { get; set; } = true;

    #endregion
}
