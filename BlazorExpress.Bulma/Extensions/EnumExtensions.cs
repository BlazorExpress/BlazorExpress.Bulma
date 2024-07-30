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

    public static string? ToButtonsSizeClass(this ButtonSize size) =>
        size switch
        {
            ButtonSize.Small => BulmaCssClass.AreSmall,
            ButtonSize.Medium => BulmaCssClass.AreMedium,
            ButtonSize.Large => BulmaCssClass.AreLarge,
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

    public static string? ToIconColorClass(this IconColor color) =>
        color switch
        {
            IconColor.Primary => BulmaCssClass.HasTextPrimary,
            IconColor.Link => BulmaCssClass.HasTextLink,
            IconColor.Info => BulmaCssClass.HasTextInfo,
            IconColor.Success => BulmaCssClass.HasTextSuccess,
            IconColor.Warning => BulmaCssClass.HasTextWarning,
            IconColor.Danger => BulmaCssClass.HasTextDanger,
            IconColor.White => BulmaCssClass.HasTextWhite,
            IconColor.Black => BulmaCssClass.HasTextBlack,
            IconColor.Light => BulmaCssClass.HasTextLight,
            IconColor.Dark => BulmaCssClass.HasTextDark,
            _ => null,
        };

    public static string? ToIconSizeClass(this IconSize size) =>
        size switch
        {
            IconSize.Small => BulmaCssClass.IsSmall,
            IconSize.Medium => BulmaCssClass.IsMedium,
            IconSize.Large => BulmaCssClass.IsLarge,
            _ => null,
        };

    public static string? ToNavbarDropdownPositionClass(this NavbarDropdownPosition position) =>
        position switch
        {
            NavbarDropdownPosition.Left => BulmaCssClass.IsLeft,
            NavbarDropdownPosition.Right => BulmaCssClass.IsRight,
            _ => null
        };

    public static string? ToPaginationAlignmentClass(this PaginationAlignment alignment) =>
        alignment switch
        {
            PaginationAlignment.Left => BulmaCssClass.IsLeft,
            PaginationAlignment.Center => BulmaCssClass.IsCentered,
            PaginationAlignment.Right => BulmaCssClass.IsRight,
            _ => null
        };

    public static string? ToPaginationLinkTypeClass(this PaginationLinkType linkType) =>
        linkType switch
        {
            PaginationLinkType.Previous => BulmaCssClass.PaginationPrevious,
            PaginationLinkType.Next => BulmaCssClass.PaginationNext,
            _ => BulmaCssClass.PaginationLink
        };

    public static string? ToPaginationSizeClass(this PaginationSize size) =>
        size switch
        {
            PaginationSize.Small => BulmaCssClass.IsSmall,
            PaginationSize.Medium => BulmaCssClass.IsMedium,
            PaginationSize.Large => BulmaCssClass.IsLarge,
            _ => null,
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

    public static string? ToSkeletonColorClass(this SkeletonColor color) =>
        color switch
        {
            SkeletonColor.Primary => BulmaCssClass.HasBackgroundPrimary,
            SkeletonColor.Link => BulmaCssClass.HasBackgroundLink,
            SkeletonColor.Info => BulmaCssClass.HasBackgroundInfo,
            SkeletonColor.Success => BulmaCssClass.HasBackgroundSuccess,
            SkeletonColor.Warning => BulmaCssClass.HasBackgroundWarning,
            SkeletonColor.Danger => BulmaCssClass.HasBackgroundDanger,
            SkeletonColor.White => BulmaCssClass.HasBackgroundWhite,
            SkeletonColor.Black => BulmaCssClass.HasBackgroundBlack,
            SkeletonColor.Light => BulmaCssClass.HasBackgroundLight,
            SkeletonColor.Dark => BulmaCssClass.HasBackgroundDark,
            _ => null,
        };

    public static string? ToSkeletonTypeClass(this SkeletonType type) =>
        type switch
        {
            SkeletonType.Block => BulmaCssClass.SkeletonBlock,
            SkeletonType.Lines => BulmaCssClass.SkeletonLines,
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
