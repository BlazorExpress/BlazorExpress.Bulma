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

    public static DeviceType ToDeviceTypeEnum(this float width) =>
        width switch
        {
            <= 768 => DeviceType.Mobile,
            ( > 768) and (<= 1023) => DeviceType.Tablet,
            (> 1023) and (<= 1215) => DeviceType.Desktop,
            (> 1215) and (<= 1407) => DeviceType.Widescreen,
            (> 1407) or _ => DeviceType.FullHD
        };

    #endregion
}
