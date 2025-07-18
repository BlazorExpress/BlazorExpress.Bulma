﻿namespace BlazorExpress.Bulma.Demo.RCL;

public partial class DemosMainLayout : MainLayoutBase
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

        // FEATURES
        groups.Add(new LinkGroup
        {
            Name = "FEATURES",
            CssClass = "is-size-7 has-text-weight-bold has-text-warning",
            Links = [
                new Link { Href = DemoRouteConstants.Demos_Skeletons_Documentation, Text = "Skeletons" }
            ]
        });

        // ICONS
        groups.Add(new LinkGroup
        {
            Name = "ICONS",
            CssClass = "is-size-7 has-text-weight-bold has-text-info",
            Links = [
                new Link { Href = DemoRouteConstants.Demos_BootstrapIcons_Documentation, Text = "Bootstrap Icons" },
                new Link { Href = DemoRouteConstants.Demos_GoogleFontIcons_Documentation, Text = "Google Font Icons" }
            ]
        });

        // ELEMENTS
        groups.Add(new LinkGroup
        {
            Name = "ELEMENTS",
            CssClass = "is-size-7 has-text-weight-bold has-text-primary",
            Links = [
                new Link { Href = DemoRouteConstants.Demos_Block_Documentation, Text = "Block" },
                new Link { Href = DemoRouteConstants.Demos_Box_Documentation, Text = "Box" },
                new Link { Href = DemoRouteConstants.Demos_Button_Documentation, Text = "Button" },
                new Link { Href = DemoRouteConstants.Demos_DeleteButton_Documentation, Text = "Delete Button" },
                new Link { Href = DemoRouteConstants.Demos_Image_Documentation, Text = "Image" },
                new Link { Href = DemoRouteConstants.Demos_Notification_Documentation, Text = "Notification" },
                new Link { Href = DemoRouteConstants.Demos_ProgressBar_Documentation, Text = "Progress Bar" },
                new Link { Href = DemoRouteConstants.Demos_Tags_Documentation, Text = "Tags" },
            ]
        });

        // FORM
        groups.Add(new LinkGroup
        {
            Name = "FORM",
            CssClass = "is-size-7 has-text-weight-bold has-text-primary",
            Links = [
                new Link { Href = DemoRouteConstants.Demos_Form_DateInput_Documentation , Text = "Date Input" },
                new Link { Href = DemoRouteConstants.Demos_Form_EnumInput_Documentation , Text = "Enum Input" },
                new Link { Href = DemoRouteConstants.Demos_Form_OTPInput_Documentation , Text = "OTP Input" },
                new Link { Href = DemoRouteConstants.Demos_Form_TextInput_Documentation , Text = "Text Input" },
            ]
        });

        // COMPONENTS
        groups.Add(new LinkGroup
        {
            Name = "COMPONENTS",
            CssClass = "is-size-7 has-text-weight-bold has-text-dark",
            Links = [
                new Link { Href = DemoRouteConstants.Demos_Breadcrumb_Documentation, Text = "Breadcrumb" },
                new Link { Href = DemoRouteConstants.Demos_ConfirmDialog_Documentation, Text = "Confirm Dialog" },
                new Link { Href = DemoRouteConstants.Demos_GoogleMaps_Documentation, Text = "Google Maps" },
                new Link { Href = DemoRouteConstants.Demos_Grid_Documentation, Text = "Grid" },
                new Link { Href = DemoRouteConstants.Demos_Message_Documentation, Text = "Message" },
                new Link { Href = DemoRouteConstants.Demos_Modal_Documentation, Text = "Modal" },
                new Link { Href = DemoRouteConstants.Demos_Pagination_Documentation, Text = "Pagination" },
                new Link { Href = DemoRouteConstants.Demos_ScriptLoader_Documentation, Text = "Script Loader" },
                new Link { Href = DemoRouteConstants.Demos_Tabs_Documentation, Text = "Tabs" }
            ]
        });        

        // LAYOUT
        groups.Add(new LinkGroup
        {
            Name = "LAYOUT",
            CssClass = "is-size-7 has-text-weight-bold has-text-success",
            Links = [
                new Link { Href = DemoRouteConstants.Demos_Hero_Documentation, Text = "Hero" }
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
