namespace BlazorExpress.Bulma;

public static class EnumExtensions
{
    #region Methods

    public static string ToNavbarDropdownPositionClass(this NavbarDropdownPosition position) =>
        position switch
        {
            NavbarDropdownPosition.Left => BulmaCssClass.IsLeft,
            NavbarDropdownPosition.Right => BulmaCssClass.IsRight,
            _ => ""
        };

    #endregion
}
