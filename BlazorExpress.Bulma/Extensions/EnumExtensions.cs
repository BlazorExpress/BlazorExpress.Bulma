namespace BlazorExpress.Bulma;

public static class EnumExtensions
{
    #region Methods

    public static DeviceType ToDeviceTypeEnum(this float width) =>
        width switch
        {
            <= 768 => DeviceType.Mobile,
            (> 768) and (<= 1023) => DeviceType.Tablet,
            (> 1023) and (<= 1215) => DeviceType.Desktop,
            (> 1215) and (<= 1407) => DeviceType.Widescreen,
            (> 1407) or _ => DeviceType.FullHD
        };

    public static string? ToNavbarDropdownPositionClass(this NavbarDropdownPosition position) =>
        position switch
        {
            NavbarDropdownPosition.Left => BulmaCssClass.IsLeft,
            NavbarDropdownPosition.Right => BulmaCssClass.IsRight,
            _ => null
        };

    public static string? ToTitleSizeClass(this HeadingSize headingSize) =>
        headingSize switch
        {
            HeadingSize.H1 => $"{BulmaCssClass.Title} {BulmaCssClass.Is1}",
            HeadingSize.H2 => $"{BulmaCssClass.Title} {BulmaCssClass.Is2}",
            HeadingSize.H3 => $"{BulmaCssClass.Title} {BulmaCssClass.Is3}",
            HeadingSize.H4 => $"{BulmaCssClass.Title} {BulmaCssClass.Is4}",
            HeadingSize.H5 => $"{BulmaCssClass.Title} {BulmaCssClass.Is5}",
            HeadingSize.H6 => $"{BulmaCssClass.Title} {BulmaCssClass.Is6}",
            _ => null
        };

    public static string? ToSubTitleSizeClass(this HeadingSize headingSize) =>
        headingSize switch
        {
            HeadingSize.H1 => $"{BulmaCssClass.SubTitle} {BulmaCssClass.Is1}",
            HeadingSize.H2 => $"{BulmaCssClass.SubTitle} {BulmaCssClass.Is2}",
            HeadingSize.H3 => $"{BulmaCssClass.SubTitle} {BulmaCssClass.Is3}",
            HeadingSize.H4 => $"{BulmaCssClass.SubTitle} {BulmaCssClass.Is4}",
            HeadingSize.H5 => $"{BulmaCssClass.SubTitle} {BulmaCssClass.Is5}",
            HeadingSize.H6 => $"{BulmaCssClass.SubTitle} {BulmaCssClass.Is6}",
            _ => null
        };

    #endregion
}
