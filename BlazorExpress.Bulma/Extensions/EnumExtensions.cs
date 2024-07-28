namespace BlazorExpress.Bulma;

public static class EnumExtensions
{
    #region Methods

    public static string? ToButtonColorClass(this ButtonColor color) =>
        color switch
        {
            ButtonColor.Primary => BulmaCssClass.IsPrimary,
            ButtonColor.Link => BulmaCssClass.IsLink,
            ButtonColor.Info => BulmaCssClass.IsInfo,
            ButtonColor.Success => BulmaCssClass.IsSuccess,
            ButtonColor.Warning => BulmaCssClass.IsWarning,
            ButtonColor.Danger => BulmaCssClass.IsDanger,
            ButtonColor.White => BulmaCssClass.IsWhite,
            ButtonColor.Light => BulmaCssClass.IsLight,
            ButtonColor.Dark => BulmaCssClass.IsDark,
            ButtonColor.Black => BulmaCssClass.IsBlack,
            ButtonColor.Text => BulmaCssClass.IsText,
            ButtonColor.Ghost => BulmaCssClass.IsGhost,
            _ => null,
        };

    public static string? ToButtonSizeClass(this ButtonSize size) =>
        size switch
        {
            ButtonSize.Small => BulmaCssClass.IsSmall,
            ButtonSize.Normal => BulmaCssClass.IsNormal,
            ButtonSize.Medium => BulmaCssClass.IsMedium,
            ButtonSize.Large => BulmaCssClass.IsLarge,
            _ => null,
        };

    public static string? ToButtonTypeString(this ButtonType type) =>
        type switch
        {
            ButtonType.Submit => BulmaCssClass.Submit,
            ButtonType.Reset  => BulmaCssClass.Reset,
            _ => BulmaCssClass.Button,
        };

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

    public static string? ToTabsAlignmentClass(this TabsAlignment alignment) =>
        alignment switch
        {
            TabsAlignment.Center => BulmaCssClass.IsCentered,
            TabsAlignment.Left => BulmaCssClass.IsLeft,
            TabsAlignment.Right => BulmaCssClass.IsRight,
            _ => null
        };

    public static string? ToTabsSizeClass(this TabsSize size) =>
        size switch
        {
            TabsSize.Large => BulmaCssClass.IsLarge,
            TabsSize.Medium => BulmaCssClass.IsMedium,
            TabsSize.Small => BulmaCssClass.IsSmall,
            _ => null
        };

    public static string? ToTabsTypeClass(this TabsType type) =>
        type switch
        {
            TabsType.Boxed => BulmaCssClass.IsBoxed,
            TabsType.Rounded => $"{BulmaCssClass.IsToggle} {BulmaCssClass.IsToggleRounded}",
            _ => null
        };

    #endregion
}
