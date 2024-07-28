namespace BlazorExpress.Bulma.Demo.RCL;

public partial class MainLayout : MainLayoutBase
{
    Menu menuRef = default!;
    bool isNavbarMenuActive = false;
    bool isNavbarBurgerActive = false;
    bool isNavMenuToggleButtonActive = false;
    HashSet<LinkGroup> linkGroups = new();

    protected override void OnInitialized()
    {
        if (!linkGroups.Any())
            linkGroups = GetLinkGroups();

        base.OnInitialized();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("initializeTheme");

        await base.OnAfterRenderAsync(firstRender);
    }

    HashSet<LinkGroup> GetLinkGroups()
    {
        var groups = new HashSet<LinkGroup>();

        // ELEMENTS
        groups.Add(new LinkGroup
        {
            Name = "ELEMENTS",
            CssClass = "is-size-7 has-text-weight-bold has-text-info",
            Links = [
                    new Link { Href=@RouteConstants.Demos_Block_Documentation, Text = "Block" },
                    new Link { Href=@RouteConstants.Demos_Box_Documentation, Text = "Box" },
                    new Link { Href=@RouteConstants.Demos_Button_Documentation, Text = "Button" },
                    new Link { Href=@RouteConstants.Demos_Icon_Documentation, Text = "Icon" },
            ]
        });


        // COMPONENTS
        groups.Add(new LinkGroup
        {
            Name = "COMPONENTS",
            CssClass = "is-size-7 has-text-weight-bold has-text-primary",
            Links = [
                    new Link { Href=@RouteConstants.Demos_Message_Documentation, Text = "Message" },
                    new Link { Href=@RouteConstants.Demos_Tabs_Documentation, Text = "Tabs" },
            ]
        });

        // FORM
        //groups.Add(new LinkGroup
        //{
        //    Name = "FORM",
        //    CssClass = "is-size-7 has-text-weight-bold has-text-link",
        //    Links = [
        //            new Link { Href=@RouteConstants.Demos_Block_Documentation, Text = "Block", Match = NavLinkMatch.All },
        //    ]
        //});

        // COLUMNS
        //groups.Add(new LinkGroup
        //{
        //    Name = "COLUMNS",
        //    CssClass = "is-size-7 has-text-weight-bold has-text-danger",
        //    Links = [
        //            new Link { Href=@RouteConstants.Demos_Block_Documentation, Text = "Block", Match = NavLinkMatch.All },
        //    ]
        //});

        // GRID
        //groups.Add(new LinkGroup
        //{
        //    Name = "GRID",
        //    CssClass = "is-size-7 has-text-weight-bold has-text-warning",
        //    Links = [
        //            new Link { Href=@RouteConstants.Demos_Block_Documentation, Text = "Block", Match = NavLinkMatch.All },
        //    ]
        //});

        // LAYOUT
        groups.Add(new LinkGroup
        {
            Name = "LAYOUT",
            CssClass = "is-size-7 has-text-weight-bold has-text-success",
            Links = [
                    new Link { Href=@RouteConstants.Demos_Hero_Documentation, Text = "Hero" },
            ]
        });

        return groups;
    }

    Task SetLightTheme() => SetTheme("light");

    Task SetDarkTheme() => SetTheme("dark");

    Task SetAutoTheme() => SetTheme("system");

    async Task SetTheme(string themeName) => await JS.InvokeVoidAsync("setTheme", themeName);

    void ShowNavbarMenu(bool isActive)
    {
        isNavbarBurgerActive = isActive;
        isNavbarMenuActive = isActive;
    }

    void ShowMenu() => menuRef.Toggle();

    void OnMenuStateChanged(bool isVisible)
    {
        isNavMenuToggleButtonActive = isVisible;
    }
}

public class LinkGroup
{
    public string? Name { get; set; }
    public string? CssClass { get; set; }
    public HashSet<Link>? Links { get; set; }
}

public class Link
{
    public string? Href { get; set; }
    public string? Text { get; set; }
    public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;

    public LinkGroup? Group { get; set; }
}
