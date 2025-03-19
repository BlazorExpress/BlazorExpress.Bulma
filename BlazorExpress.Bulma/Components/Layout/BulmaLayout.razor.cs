namespace BlazorExpress.Bulma;

/// <summary>
/// Bulma layout component
/// </summary>
public partial class BulmaLayout : BulmaLayoutComponentBase
{
    #region Fields and Constants

    private bool isNavbarBurgerActive;
    private bool isNavbarMenuActive;
    private bool isNavMenuToggleButtonActive;
    private HashSet<LinkGroup> linkGroups = new();
    private Menu menuRef = default!;

    #endregion

    #region Methods

    private void OnMenuStateChanged(bool isVisible)
    {
        isNavMenuToggleButtonActive = isVisible;
    }

    private Task SetAutoTheme() => SetTheme("system");

    private Task SetDarkTheme() => SetTheme("dark");

    private Task SetLightTheme() => SetTheme("light");

    private async Task SetTheme(string themeName) => await JSRuntime.InvokeVoidAsync("setTheme", themeName);

    private void ShowMenu() => menuRef.Toggle();

    private void ShowNavbarMenu(bool isActive)
    {
        isNavbarBurgerActive = isActive;
        isNavbarMenuActive = isActive;
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            ("be-bulma-page", true)
        );

    // width
    // height

    [Parameter] public RenderFragment? ContentSection { get; set; }

    private string? ContentSectionClassNames =>
        BuildClassNames(
            ContentSectionCssClass,
            ("be-bulma-page-content p-5", true)
        );

    [Parameter] public string? ContentSectionCssClass { get; set; } = null;

    [Parameter] public string? ContentSectionCssStyle { get; set; } = null;

    private string? ContentSectionStyleNames =>
        BuildClassNames(
            ContentSectionCssStyle, 
            ($"--be-bulma-menu-width: 0px !important", SidebarSection is null)
        );

    [Parameter] public RenderFragment? FooterSection { get; set; }

    [Parameter] public string? FooterSectionCssClass { get; set; } = "bg-body-tertiary";

    private string? FooterSectionCssClassNames =>
        BuildClassNames(
            FooterSectionCssClass,
            ("be-bulma-page-footer p-4", true)
        );

    [Parameter] public RenderFragment? HeaderSection { get; set; }

    [Parameter] public string? HeaderSectionCssClass { get; set; } = "d-flex justify-content-end";

    [Parameter] public RenderFragment? SidebarSection { get; set; }

    private string? SidebarSectionClassNames =>
        BuildClassNames(
            SidebarSectionCssClass,
            ("be-bulma-page-sidebar", true)
        );

    [Parameter] public string? SidebarSectionCssClass { get; set; }

    [Parameter] public string? SidebarSectionCssStyle { get; set; }

    private string? SidebarSectionStyleNames =>
        BuildStyleNames(
            SidebarSectionCssStyle,
            ($"--be-bulma-menu-width: {SidebarWidth.ToString(CultureInfo.InvariantCulture)}px", SidebarSection is not null && SidebarWidth > 0)
        );

    /// <summary>
    /// Gets or sets the sidebar width in pixels.
    /// </summary>
    [Parameter]
    public float SidebarWidth { get; set; } = 256;

    #endregion
}
