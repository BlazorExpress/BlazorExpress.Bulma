namespace BlazorExpress.Bulma.Demo.RCL;

public partial class MainLayout : MainLayoutBase
{
    Menu menuRef = default!;
    bool isNavBarActive = false;
    bool isMenuToggleButtonVisible = false;
    bool isMenuVisible = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JS.InvokeVoidAsync("initializeTheme");

        await base.OnAfterRenderAsync(firstRender);
    }

    void OnNavbarBurgerActiveStateChanged(bool isActive) => isNavBarActive = isActive;

    Task SetLightTheme() => SetTheme("light");

    Task SetDarkTheme() => SetTheme("dark");

    Task SetAutoTheme() => SetTheme("system");

    async Task SetTheme(string themeName) => await JS.InvokeVoidAsync("setTheme", themeName);

    void ShowMenu()
    {
        isMenuVisible = menuRef.Toggle();
    }

    void OnWindowResize(WindowResizeEventArgs args)
    {
        isMenuToggleButtonVisible = args.DeviceType == DeviceType.Mobile;
    }
}
