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
            _ => null
        };

    public static string? ToButtonSizeClass(this ButtonSize size) =>
        size switch
        {
            ButtonSize.Small => BulmaCssClass.IsSmall,
            ButtonSize.Normal => BulmaCssClass.IsNormal,
            ButtonSize.Medium => BulmaCssClass.IsMedium,
            ButtonSize.Large => BulmaCssClass.IsLarge,
            _ => null
        };

    public static string? ToButtonsSizeClass(this ButtonSize size) =>
        size switch
        {
            ButtonSize.Small => BulmaCssClass.AreSmall,
            ButtonSize.Medium => BulmaCssClass.AreMedium,
            ButtonSize.Large => BulmaCssClass.AreLarge,
            _ => null
        };

    public static string? ToButtonTypeString(this ButtonType type) =>
        type switch
        {
            ButtonType.Submit => BulmaCssClass.Submit,
            ButtonType.Reset => BulmaCssClass.Reset,
            _ => BulmaCssClass.Button
        };

    public static string? ToDeleteButtonSizeClass(this DeleteButtonSize size) =>
        size switch
        {
            DeleteButtonSize.Small => BulmaCssClass.IsSmall,
            DeleteButtonSize.Normal => BulmaCssClass.IsNormal,
            DeleteButtonSize.Medium => BulmaCssClass.IsMedium,
            DeleteButtonSize.Large => BulmaCssClass.IsLarge,
            _ => null
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
            _ => null
        };

    public static string? ToIconSizeClass(this IconSize size) =>
        size switch
        {
            IconSize.Small => BulmaCssClass.IsSmall,
            IconSize.Medium => BulmaCssClass.IsMedium,
            IconSize.Large => BulmaCssClass.IsLarge,
            _ => null
        };

    public static string? ToImageDimensionClass(this ImageDimension dimension) =>
        dimension switch
        {
            ImageDimension.Is16x16 => BulmaCssClass.Is16x16,
            ImageDimension.Is24x24 => BulmaCssClass.Is24x24,
            ImageDimension.Is32x32 => BulmaCssClass.Is32x32,
            ImageDimension.Is48x48 => BulmaCssClass.Is48x48,
            ImageDimension.Is64x64 => BulmaCssClass.Is64x64,
            ImageDimension.Is96x96 => BulmaCssClass.Is96x96,
            ImageDimension.Is128x128 => BulmaCssClass.Is128x128,
            _ => null
        };

    public static string? ToImageRatioClass(this ImageRatio ratio) =>
        ratio switch
        {
            ImageRatio.IsSquare => BulmaCssClass.IsSquare,
            ImageRatio.Is1by1 => BulmaCssClass.Is1by1,
            ImageRatio.Is1by2 => BulmaCssClass.Is1by2,
            ImageRatio.Is1by3 => BulmaCssClass.Is1by3,
            ImageRatio.Is2by1 => BulmaCssClass.Is2by1,
            ImageRatio.Is2by3 => BulmaCssClass.Is2by3,
            ImageRatio.Is3by1 => BulmaCssClass.Is3by1,
            ImageRatio.Is3by2 => BulmaCssClass.Is3by2,
            ImageRatio.Is3by4 => BulmaCssClass.Is3by4,
            ImageRatio.Is3by5 => BulmaCssClass.Is3by5,
            ImageRatio.Is4by3 => BulmaCssClass.Is4by3,
            ImageRatio.Is4by5 => BulmaCssClass.Is4by5,
            ImageRatio.Is5by3 => BulmaCssClass.Is5by3,
            ImageRatio.Is5by4 => BulmaCssClass.Is5by4,
            ImageRatio.Is9by16 => BulmaCssClass.Is9by16,
            ImageRatio.Is16by9 => BulmaCssClass.Is16by9,
            _ => null
        };

    public static string? ToMessageColorClass(this MessageColor color) =>
        color switch
        {
            MessageColor.Primary => BulmaCssClass.IsPrimary,
            MessageColor.Link => BulmaCssClass.IsLink,
            MessageColor.Info => BulmaCssClass.IsInfo,
            MessageColor.Success => BulmaCssClass.IsSuccess,
            MessageColor.Warning => BulmaCssClass.IsWarning,
            MessageColor.Danger => BulmaCssClass.IsDanger,
            MessageColor.Dark => BulmaCssClass.IsDark,
            _ => null
        };

    public static string? ToMessageSizeClass(this MessageSize size) =>
        size switch
        {
            MessageSize.Small => BulmaCssClass.IsSmall,
            MessageSize.Medium => BulmaCssClass.IsMedium,
            MessageSize.Large => BulmaCssClass.IsLarge,
            _ => null
        };

    public static string? ToNavbarDropdownPositionClass(this NavbarDropdownPosition position) =>
        position switch
        {
            NavbarDropdownPosition.Left => BulmaCssClass.IsLeft,
            NavbarDropdownPosition.Right => BulmaCssClass.IsRight,
            _ => null
        };

    public static string? ToNotificationColorClass(this NotificationColor color) =>
        color switch
        {
            NotificationColor.Primary => BulmaCssClass.IsPrimary,
            NotificationColor.Link => BulmaCssClass.IsLink,
            NotificationColor.Info => BulmaCssClass.IsInfo,
            NotificationColor.Success => BulmaCssClass.IsSuccess,
            NotificationColor.Warning => BulmaCssClass.IsWarning,
            NotificationColor.Danger => BulmaCssClass.IsDanger,
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
            _ => null
        };

    public static string? ToProgressBarColorClass(this ProgressBarColor color) =>
        color switch
        {
            ProgressBarColor.Primary => BulmaCssClass.IsPrimary,
            ProgressBarColor.Link => BulmaCssClass.IsLink,
            ProgressBarColor.Info => BulmaCssClass.IsInfo,
            ProgressBarColor.Success => BulmaCssClass.IsSuccess,
            ProgressBarColor.Warning => BulmaCssClass.IsWarning,
            ProgressBarColor.Danger => BulmaCssClass.IsDanger,
            _ => null
        };

    public static string? ToProgressBarSizeClass(this ProgressBarSize size) =>
        size switch
        {
            ProgressBarSize.Small => BulmaCssClass.IsSmall,
            ProgressBarSize.Normal => BulmaCssClass.IsNormal,
            ProgressBarSize.Medium => BulmaCssClass.IsMedium,
            ProgressBarSize.Large => BulmaCssClass.IsLarge,
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
            _ => null
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

    public static string? ToTagColorClass(this TagColor color) =>
        color switch
        {
            TagColor.Black => BulmaCssClass.IsBlack,
            TagColor.Dark => BulmaCssClass.IsDark,
            TagColor.Light => BulmaCssClass.IsLight,
            TagColor.White => BulmaCssClass.IsWhite,
            TagColor.Primary => BulmaCssClass.IsPrimary,
            TagColor.Link => BulmaCssClass.IsLink,
            TagColor.Info => BulmaCssClass.IsInfo,
            TagColor.Success => BulmaCssClass.IsSuccess,
            TagColor.Warning => BulmaCssClass.IsWarning,
            TagColor.Danger => BulmaCssClass.IsDanger,
            _ => null
        };

    public static string? ToTagSizeClass(this TagSize size) =>
        size switch
        {
            TagSize.Normal => BulmaCssClass.IsNormal,
            TagSize.Medium => BulmaCssClass.IsMedium,
            TagSize.Large => BulmaCssClass.IsLarge,
            _ => null
        };

    public static string? ToTagsSizeClass(this TagSize size) =>
        size switch
        {
            TagSize.Medium => BulmaCssClass.AreMedium,
            TagSize.Large => BulmaCssClass.AreLarge,
            _ => null
        };

    public static string ToTextAlignmentClass(this Alignment alignment) =>
        alignment switch
        {
            Alignment.Start => BulmaCssClass.HasTextLeft,
            Alignment.Center => BulmaCssClass.HasTextCentered,
            Alignment.End => BulmaCssClass.HasTextRight,
            _ => ""
        };

    public static string? ToTextInputColorClass(this TextInputColor color) =>
        color switch
        {
            TextInputColor.Primary => BulmaCssClass.IsPrimary,
            TextInputColor.Link => BulmaCssClass.IsLink,
            TextInputColor.Info => BulmaCssClass.IsInfo,
            TextInputColor.Success => BulmaCssClass.IsSuccess,
            TextInputColor.Warning => BulmaCssClass.IsWarning,
            TextInputColor.Danger => BulmaCssClass.IsDanger,
            _ => null
        };

    public static string? ToTextInputSizeClass(this TextInputSize size) =>
        size switch
        {
            TextInputSize.Small => BulmaCssClass.IsSmall,
            TextInputSize.Normal => BulmaCssClass.IsNormal,
            TextInputSize.Medium => BulmaCssClass.IsMedium,
            TextInputSize.Large => BulmaCssClass.IsLarge,
            _ => null
        };

    public static string? ToTextInputStateClass(this TextInputState size) =>
        size switch
        {
            TextInputState.Hovered => BulmaCssClass.IsHovered,
            TextInputState.Focused => BulmaCssClass.IsFocused,
            TextInputState.Loading => BulmaCssClass.IsLoading,
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

    public static string ToUnitCssString(this Unit unit) =>
        unit switch
        {
            Unit.Em => "em",
            Unit.Percentage => "%",
            Unit.Pt => "pt",
            Unit.Px => "px",
            Unit.Rem => "rem",
            Unit.Vh => "vh",
            Unit.VMax => "vmax",
            Unit.VMin => "vmin",
            Unit.Vw => "vw",
            _ => string.Empty
        };

    #endregion
}
