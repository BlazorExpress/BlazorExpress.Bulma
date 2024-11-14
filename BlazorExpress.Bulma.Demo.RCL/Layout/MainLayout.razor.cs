namespace BlazorExpress.Bulma.Demo.RCL;

public partial class MainLayout : MainLayoutBase
{
    #region Fields and Constants

    private bool isNavbarBurgerActive;
    private bool isNavbarMenuActive;
    private bool isNavMenuToggleButtonActive;
    private HashSet<LinkGroup> linkGroups = new();
    private Menu menuRef = default!;

    #endregion

    #region Methods

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        //if (firstRender)
        //    await JS.InvokeVoidAsync("initializeTheme");

        await base.OnAfterRenderAsync(firstRender);
    }

    protected override void OnInitialized()
    {
        if (!linkGroups.Any())
            linkGroups = GetLinkGroups();

        base.OnInitialized();
    }

    private HashSet<LinkGroup> GetLinkGroups()
    {
        var groups = new HashSet<LinkGroup>();

        // FEATURES
        groups.Add(new LinkGroup
        {
            Name = "FEATURES",
            CssClass = "is-size-7 has-text-weight-bold has-text-warning",
            Links = [
                new Link { Href = RouteConstants.Demos_Skeletons_Documentation, Text = "Skeletons" }
            ]
        });

        // ELEMENTS
        groups.Add(new LinkGroup
        {
            Name = "ELEMENTS",
            CssClass = "is-size-7 has-text-weight-bold has-text-info",
            Links = [
                new Link { Href = RouteConstants.Demos_Block_Documentation, Text = "Block" },
                new Link { Href = RouteConstants.Demos_Box_Documentation, Text = "Box" },
                new Link { Href = RouteConstants.Demos_Button_Documentation, Text = "Button" },
                new Link { Href = RouteConstants.Demos_Icon_Documentation, Text = "Icon" },
                new Link { Href = RouteConstants.Demos_GoogleFontIcon_Documentation, Text = "Google Font Icons" }
            ]
        });

        // COMPONENTS
        groups.Add(new LinkGroup
        {
            Name = "COMPONENTS",
            CssClass = "is-size-7 has-text-weight-bold has-text-primary",
            Links = [
                new Link { Href = RouteConstants.Demos_Message_Documentation, Text = "Message" },
                new Link { Href = RouteConstants.Demos_GoogleMaps_Documentation, Text = "Google Maps" },
                new Link { Href = RouteConstants.Demos_Grid_Documentation, Text = "Grid" },
                new Link { Href = RouteConstants.Demos_Pagination_Documentation, Text = "Pagination" },
                new Link { Href = RouteConstants.Demos_ScriptLoader_Documentation, Text = "Script Loader" },
                new Link { Href = RouteConstants.Demos_Tabs_Documentation, Text = "Tabs" }
            ]
        });
        

        // LAYOUT
        groups.Add(new LinkGroup
        {
            Name = "LAYOUT",
            CssClass = "is-size-7 has-text-weight-bold has-text-success",
            Links = [
                new Link { Href = RouteConstants.Demos_Hero_Documentation, Text = "Hero" }
            ]
        });

        return groups;
    }

    private void OnMenuStateChanged(bool isVisible)
    {
        isNavMenuToggleButtonActive = isVisible;
    }

    private Task SetAutoTheme() => SetTheme("system");

    private Task SetDarkTheme() => SetTheme("dark");

    private Task SetLightTheme() => SetTheme("light");

    private async Task SetTheme(string themeName) => await JS.InvokeVoidAsync("setTheme", themeName);

    private void ShowMenu() => menuRef.Toggle();

    private void ShowNavbarMenu(bool isActive)
    {
        isNavbarBurgerActive = isActive;
        isNavbarMenuActive = isActive;
    }

    #endregion
}
