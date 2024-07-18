namespace BlazorExpress.Bulma.Demo.RCL;

public partial class MainLayout : MainLayoutBase
{
    bool isMenuActive = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("initializeTheme");

        await base.OnAfterRenderAsync(firstRender);
    }

    void OnNavbarBurgerActiveStateChanged(bool isActive) => isMenuActive = isActive;

    Task SetLightTheme() => SetTheme("light");

    Task SetDarkTheme() => SetTheme("dark");

    Task SetAutoTheme() => SetTheme("system");

    async Task SetTheme(string themeName) => await JS.InvokeVoidAsync("setTheme", themeName);
}
