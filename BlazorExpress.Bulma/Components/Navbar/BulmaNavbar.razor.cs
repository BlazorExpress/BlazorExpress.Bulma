namespace BlazorExpress.Bulma;

public partial class BulmaNavbar : BulmaComponentBase
{
    private bool isNavbarBurgerActive;
    private bool isNavbarMenuActive;
    private bool isNavMenuToggleButtonActive;
    private Menu menuRef = default!;

    [Parameter] public string? ApplicationName { get; set; }

    [Parameter] public string? BrandImgAltText { get; set; }

    [Parameter] public string? BrandImgSrc { get; set; }

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
}
