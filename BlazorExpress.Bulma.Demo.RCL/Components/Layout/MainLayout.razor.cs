namespace BlazorExpress.Bulma.Demo.RCL;

public partial class MainLayout : MainLayoutBase
{
    bool isMenuActive = false;

    void OnNavbarBurgerActiveStateChanged(bool isActive)
    {
        isMenuActive = isActive;
    }
}
