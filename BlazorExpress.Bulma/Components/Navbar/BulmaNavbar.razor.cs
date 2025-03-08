namespace BlazorExpress.Bulma;

public partial class BulmaNavbar : BulmaComponentBase
{
    #region Fields and Constants

    private bool navbarMenuActive;

    #endregion

    #region Methods

    private Task SetAutoTheme() => SetTheme("system");

    private Task SetDarkTheme() => SetTheme("dark");

    private Task SetLightTheme() => SetTheme("light");

    private async Task SetTheme(string themeName)
    {
        await JSRuntime.InvokeVoidAsync("setTheme", themeName);
        navbarMenuActive = false;
    }

    private void ToggleNavbarMenu(bool isActive)
    {
        navbarMenuActive = isActive;
    }

    #endregion

    #region Properties, Indexers

    [Parameter] 
    public string? ApplicationName { get; set; } = null;

    [Parameter] 
    public string? BrandImgAltText { get; set; } = null;

    [Parameter] 
    public string? BrandImgSrc { get; set; } = null;

    #endregion
}
