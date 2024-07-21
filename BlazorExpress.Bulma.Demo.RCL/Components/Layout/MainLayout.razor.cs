namespace BlazorExpress.Bulma.Demo.RCL;

public partial class MainLayout : MainLayoutBase
{
    Menu menuRef = default!;
    bool isNavbarMenuActive = false;
    bool isNavbarBurgerActive = false;
    bool isNavMenuToggleButtonActive = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("initializeTheme");

        await base.OnAfterRenderAsync(firstRender);
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
