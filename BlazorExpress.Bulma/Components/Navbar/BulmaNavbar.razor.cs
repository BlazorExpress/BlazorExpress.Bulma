namespace BlazorExpress.Bulma;

public partial class BulmaNavbar : BulmaComponentBase
{
    #region Fields and Constants
    
    private bool isNavbarMenuActive;
    private bool isNavMenuToggleButtonActive;
    private Menu menuRef = default!;

    #endregion

    #region Methods

    //private void ShowMenu() => menuRef.Toggle();

    //private void ShowNavbarMenu(bool isActive)
    //{
    //    isNavbarBurgerActive = isActive;
    //    isNavbarMenuActive = isActive;
    //}

    private void ToggleNavbarMenu(bool isActive)
    {
        isNavbarMenuActive = isActive;
        Console.WriteLine($"BulmaNavbar.isNavbarMenuActive: {isNavbarMenuActive}");
    }

    private Task SetAutoTheme() => SetTheme("system");

    private Task SetDarkTheme() => SetTheme("dark");

    private Task SetLightTheme() => SetTheme("light");

    private async Task SetTheme(string themeName)
    {
        await JSRuntime.InvokeVoidAsync("setTheme", themeName);
        isNavbarMenuActive = false;
    }

    #endregion

    #region Properties, Indexers

    [Parameter] public string? ApplicationName { get; set; }

    [Parameter] public string? BrandImgAltText { get; set; }

    [Parameter] public string? BrandImgSrc { get; set; }

    #endregion
}
