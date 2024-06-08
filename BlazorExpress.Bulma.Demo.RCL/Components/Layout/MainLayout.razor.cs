namespace BlazorExpress.Bulma.Demo.RCL;

public partial class MainLayout : LayoutComponentBase
{
    bool isMenuActive = false;

    void OnNavbarBurgerActiveStateChanged(bool isActive)
    {
        isMenuActive = isActive;
    }
}
