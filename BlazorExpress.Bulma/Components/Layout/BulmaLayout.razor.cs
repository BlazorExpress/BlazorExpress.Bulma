namespace BlazorExpress.Bulma;

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

    protected override string? CssClassNames => CssUtility.BuildClassNames(Class, ("be-bulma-page", true));
    // width
    // height

    [Parameter] public RenderFragment? ContentSection { get; set; }
    [Parameter] public string? ContentSectionCssClass { get; set; }
    protected string? ContentSectionCssClassNames => CssUtility.BuildClassNames(ContentSectionCssClass, ("be-bulma-page-body p-5", true));

    [Parameter] public RenderFragment? FooterSection { get; set; }
    [Parameter] public string? FooterSectionCssClass { get; set; } = "bg-body-tertiary";
    protected string? FooterSectionCssClassNames => CssUtility.BuildClassNames(FooterSectionCssClass, ("be-bulma-page-footer p-4", true));

    [Parameter] public RenderFragment? HeaderSection { get; set; }
    [Parameter] public string? HeaderSectionCssClass { get; set; } = "d-flex justify-content-end";

    [Parameter] public RenderFragment? SidebarSection { get; set; }
    [Parameter] public string? SidebarSectionCssClass { get; set; } = "d-flex justify-content-end";

    #endregion
}
