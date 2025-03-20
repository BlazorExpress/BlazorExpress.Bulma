namespace BlazorExpress.Bulma.Demo.RCL.Utils;

public static class PageLinkUtil
{
    public static HashSet<PageLink> GetDemosLinks()
    {
        var index = 1;
        var links = new HashSet<PageLink>();

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_AutoComplete_Documentation, Text = "AutoComplete", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.Box, Href = RouteConstants.Demos_Block_Documentation, Text = "Block", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.New, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.PersonSquare, Href = RouteConstants.Demos_BootstrapIcons_Documentation, Text = "Bootstrap Icons", Categories = new() { PageLinkCategory.All, PageLinkCategory.Icons }, Status = PageLinkStatus.Updated, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.Box, Href = RouteConstants.Demos_Box_Documentation, Text = "Box", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Breadcrumb_Documentation, Text = "Breadcrumb", Categories = new() { PageLinkCategory.All }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.ToggleOn, Href = RouteConstants.Demos_Button_Documentation, Text = "Button", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Card_Documentation, Text = "Card", Categories = new() { PageLinkCategory.All }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_CheckboxInput_Documentation, Text = "Checkbox Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.QuestionDiamondFill, Href = RouteConstants.Demos_ConfirmDialog_Documentation, Text = "Confirm Dialog", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Container_Documentation, Text = "Container", Categories = new() { PageLinkCategory.All, PageLinkCategory.Layout }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Content_Documentation, Text = "Content", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_CurrencyInput_Documentation, Text = "Currency Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_DateInput_Documentation, Text = "Date Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.XCircleFill, Href = RouteConstants.Demos_DeleteButton_Documentation, Text = "Delete Button", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Dropdown_Documentation, Text = "Dropdown", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Footer_Documentation, Text = "Footer", Categories = new() { PageLinkCategory.All, PageLinkCategory.Layout }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.PersonSquare, Href = RouteConstants.Demos_GoogleFontIcons_Documentation, Text = "Google Font Icons", Categories = new() { PageLinkCategory.All, PageLinkCategory.Icons }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.Map, Href = RouteConstants.Demos_GoogleMaps_Documentation, Text = "Google Maps", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.Grid3X2, Href = RouteConstants.Demos_Grid_Documentation, Text = "Grid", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.Box, Href = RouteConstants.Demos_Hero_Documentation, Text = "Hero", Categories = new() { PageLinkCategory.All, PageLinkCategory.Layout }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.Image, Href = RouteConstants.Demos_Image_Documentation, Text = "Image", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Getting_Started_Introduction, Text = "Introduction", Categories = new() { PageLinkCategory.All, PageLinkCategory.GettingStarted }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Level_Documentation, Text = "Level", Categories = new() { PageLinkCategory.All, PageLinkCategory.Layout }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Media_Documentation, Text = "Media", Categories = new() { PageLinkCategory.All, PageLinkCategory.Layout }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Menu_Documentation, Text = "Menu", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.EnvelopeFill, Href = RouteConstants.Demos_Message_Documentation, Text = "Message", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.WindowStack, Href = RouteConstants.Demos_Modal_Documentation, Text = "Modal", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Navbar_Documentation, Text = "Navbar", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.ExclamationTriangleFill, Href = RouteConstants.Demos_Notification_Documentation, Text = "Notification", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_NumberInput_Documentation, Text = "Number Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.ThreeDots, Href = RouteConstants.Demos_Pagination_Documentation, Text = "Pagination", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Panel_Documentation, Text = "Panel", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_PasswordInput_Documentation, Text = "Password Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.UsbCFill, Href = RouteConstants.Demos_ProgressBar_Documentation, Text = "Progress Bar", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_RadioInput_Documentation, Text = "Radio Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_RangeInput_Documentation, Text = "Range Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.CodeSlash, Href = RouteConstants.Demos_ScriptLoader_Documentation, Text = "Script Loader", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Section_Documentation, Text = "Section", Categories = new() { PageLinkCategory.All, PageLinkCategory.Layout }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_SelectInput_Documentation, Text = "Select Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.ColumnsGap, Href = RouteConstants.Demos_Skeletons_Documentation, Text = "Skeletons", Categories = new() { PageLinkCategory.All, PageLinkCategory.Features }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_Switch_Documentation, Text = "Switch", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Table_Documentation, Text = "Table", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.WindowPlus, Href = RouteConstants.Demos_Tabs_Documentation, Text = "Tabs", Categories = new() { PageLinkCategory.All, PageLinkCategory.Components }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.TagFill, Href = RouteConstants.Demos_Tags_Documentation, Text = "Tags", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.InputCursorText, Href = RouteConstants.Demos_Form_TextInput_Documentation, Text = "Text Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = true });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_TextAreaInput_Documentation, Text = "Text Area Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Form_TimeInput_Documentation, Text = "Time Input", Categories = new() { PageLinkCategory.All, PageLinkCategory.Form }, Status = PageLinkStatus.None, IsActive = false });

        index += 1;
        links.Add(new PageLink { Id = index, IconName = BootstrapIconName.None, Href = RouteConstants.Demos_Title_Documentation, Text = "Title", Categories = new() { PageLinkCategory.All, PageLinkCategory.Elements }, Status = PageLinkStatus.None, IsActive = false });

        return links;
    }
}
