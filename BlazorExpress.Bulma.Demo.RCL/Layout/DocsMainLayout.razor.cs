namespace BlazorExpress.Bulma.Demo.RCL;

public partial class DocsMainLayout : MainLayoutBase
{
    #region Fields and Constants
    
    private bool isSidebarVisible = false;
    private HashSet<LinkGroup> linkGroups = new();
    private Menu menuRef = default!;

    #endregion

    #region Methods

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("initializeTheme");

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

        // GETTING STARTED
        groups.Add(new LinkGroup
        {
            Name = "GETTING STARTED",
            CssClass = "is-size-7 has-text-weight-bold has-text-danger",
            Links = [
                new Link { Href = DemoRouteConstants.Docs_Getting_Started_Introduction, Text = "Introduction" },
                new Link { Href = DemoRouteConstants.Docs_Getting_Started_WebAssembly_NET_8, Text = "Blazor WebAssembly (.NET 8)" },
                new Link { Href = DemoRouteConstants.Docs_Getting_Started_WebApp_Server_NET_8, Text = "Blazor WebApp (.NET 8) Server" },
                //new Link { Href = RouteConstants.Docs_Getting_Started_WebApp_Auto_NET_8, Text = "Blazor WebApp (.NET 8) Auto" },
                //new Link { Href = RouteConstants.Docs_Getting_Started_MAUI_NET_8, Text = "MAUI Blazor Hybrid App (.NET 8)" },
            ]
        });

        // FEATURES
        groups.Add(new LinkGroup
        {
            Name = "FEATURES",
            CssClass = "is-size-7 has-text-weight-bold has-text-warning",
            Links = [
                new Link { Href = DemoRouteConstants.Docs_Skeletons_Documentation, Text = "Skeletons" }
            ]
        });

        // CHARTS
        groups.Add(new LinkGroup
        {
            Name = "CHARTS",
            CssClass = "is-size-7 has-text-weight-bold has-text-warning",
            Links = [
                new Link { Href = DemoRouteConstants.Docs_BarChart, Text = "Bar Chart" },
                new Link { Href = DemoRouteConstants.Docs_BubbleChart, Text = "Bubble Chart" },
                new Link { Href = DemoRouteConstants.Docs_DoughnutChart, Text = "Doughnut Chart" },
                new Link { Href = DemoRouteConstants.Docs_LineChart, Text = "Line Chart" },
                new Link { Href = DemoRouteConstants.Docs_PieChart, Text = "Pie Chart" },
                new Link { Href = DemoRouteConstants.Docs_PolarAreaChart, Text = "PolarArea Chart" },
                new Link { Href = DemoRouteConstants.Docs_RadarChart, Text = "Radar Chart" },
                new Link { Href = DemoRouteConstants.Docs_ScatterChart, Text = "Scatter Chart" }
            ]
        });

        // ICONS
        groups.Add(new LinkGroup
        {
            Name = "ICONS",
            CssClass = "is-size-7 has-text-weight-bold has-text-info",
            Links = [
                new Link { Href = DemoRouteConstants.Docs_BootstrapIcons_Documentation, Text = "Bootstrap Icons" },
                new Link { Href = DemoRouteConstants.Docs_GoogleFontIcons_Documentation, Text = "Google Font Icons" }
            ]
        });

        // ELEMENTS
        groups.Add(new LinkGroup
        {
            Name = "ELEMENTS",
            CssClass = "is-size-7 has-text-weight-bold has-text-primary",
            Links = [
                new Link { Href = DemoRouteConstants.Docs_Block_Documentation, Text = "Block" },
                new Link { Href = DemoRouteConstants.Docs_Box_Documentation, Text = "Box" },
                new Link { Href = DemoRouteConstants.Docs_Button_Documentation, Text = "Button" },
                new Link { Href = DemoRouteConstants.Docs_DeleteButton_Documentation, Text = "Delete Button" },
                new Link { Href = DemoRouteConstants.Docs_Image_Documentation, Text = "Image" },
                new Link { Href = DemoRouteConstants.Docs_Notification_Documentation, Text = "Notification" },
                new Link { Href = DemoRouteConstants.Docs_ProgressBar_Documentation, Text = "Progress Bar" },
                new Link { Href = DemoRouteConstants.Docs_Spinner_Documentation, Text = "Spinner" },
                new Link { Href = DemoRouteConstants.Docs_Tags_Documentation, Text = "Tags" },
            ]
        });

        // FORM
        groups.Add(new LinkGroup
        {
            Name = "FORM",
            CssClass = "is-size-7 has-text-weight-bold has-text-primary",
            Links = [
                new Link { Href = DemoRouteConstants.Docs_Form_CheckboxListInput_Documentation , Text = "Checkbox List Input" },
                new Link { Href = DemoRouteConstants.Docs_Form_CheckboxInput_Documentation , Text = "Checkbox Input" },
                new Link { Href = DemoRouteConstants.Docs_Form_DateInput_Documentation , Text = "Date Input" },
                new Link { Href = DemoRouteConstants.Docs_Form_EnumInput_Documentation , Text = "Enum Input" },
                new Link { Href = DemoRouteConstants.Docs_Form_NumberInput_Documentation , Text = "Number Input" },
                new Link { Href = DemoRouteConstants.Docs_Form_OTPInput_Documentation , Text = "OTP Input" },
                new Link { Href = DemoRouteConstants.Docs_Form_RadioListInput_Documentation , Text = "Radio List Input" },
                new Link { Href = DemoRouteConstants.Docs_Form_RadioInput_Documentation , Text = "Radio Input" },
                new Link { Href = DemoRouteConstants.Docs_Form_SelectInput_Documentation , Text = "Select Input" },
                new Link { Href = DemoRouteConstants.Docs_Form_TextAreaInput_Documentation , Text = "Text Area Input" },
                new Link { Href = DemoRouteConstants.Docs_Form_TextInput_Documentation , Text = "Text Input" },
            ]
        });

        // COMPONENTS
        groups.Add(new LinkGroup
        {
            Name = "COMPONENTS",
            CssClass = "is-size-7 has-text-weight-bold has-text-dark",
            Links = [
                new Link { Href = DemoRouteConstants.Docs_Breadcrumb_Documentation, Text = "Breadcrumb" },
                new Link { Href = DemoRouteConstants.Docs_Card_Documentation, Text = "Card" },
                new Link { Href = DemoRouteConstants.Docs_ConfirmDialog_Documentation, Text = "Confirm Dialog" },
                new Link { Href = DemoRouteConstants.Docs_Dropdown_Documentation, Text = "Dropdown" },
                new Link { Href = DemoRouteConstants.Docs_GoogleMap_Documentation, Text = "Google Maps" },
                new Link { Href = DemoRouteConstants.Docs_Grid_Documentation, Text = "Grid" },
                new Link { Href = DemoRouteConstants.Docs_Menu_Documentation, Text = "Menu" },
                new Link { Href = DemoRouteConstants.Docs_Message_Documentation, Text = "Message" },
                new Link { Href = DemoRouteConstants.Docs_Modal_Documentation, Text = "Modal" },
                new Link { Href = DemoRouteConstants.Docs_Navbar_Documentation, Text = "Navbar" },
                new Link { Href = DemoRouteConstants.Docs_Pagination_Documentation, Text = "Pagination" },
                new Link { Href = DemoRouteConstants.Docs_Panel_Documentation, Text = "Panel" },
                new Link { Href = DemoRouteConstants.Docs_PdfViewer_Documentation, Text = "Pdf Viewer" },
                new Link { Href = DemoRouteConstants.Docs_ScriptLoader_Documentation, Text = "Script Loader" },
                new Link { Href = DemoRouteConstants.Docs_Tabs_Documentation, Text = "Tabs" }
            ]
        });        

        // LAYOUT
        groups.Add(new LinkGroup
        {
            Name = "LAYOUT",
            CssClass = "is-size-7 has-text-weight-bold has-text-success",
            Links = [
                new Link { Href = DemoRouteConstants.Docs_Hero_Documentation, Text = "Hero" }
            ]
        });

        return groups;
    }

    private Task SetAutoTheme() => SetTheme("system");

    private Task SetDarkTheme() => SetTheme("dark");

    private Task SetLightTheme() => SetTheme("light");

    private async Task SetTheme(string themeName) => await JS.InvokeVoidAsync("setTheme", themeName);

    private void ToggleSidebarSection()
    {
        @menuRef.Toggle();
    }

    #endregion
}
