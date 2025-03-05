namespace BlazorExpress.Bulma;

public static class BulmaCssClass
{
    #region Fields and Constants

    public const string AreSmall = "are-small";
    public const string AreMedium = "are-medium";
    public const string AreLarge = "are-large";

    public const string Block = "block";

    public const string Box = "box";

    public const string Button = "button";
    public const string Buttons = "buttons";

    public const string Control = "control";

    public const string Delete = "delete";

    public const string HasBackgroundBlack = "has-background-black";
    public const string HasBackgroundDanger = "has-background-danger";
    public const string HasBackgroundDark = "has-background-dark";
    public const string HasBackgroundInfo = "has-background-info";
    public const string HasBackgroundLight = "has-background-light";
    public const string HasBackgroundLink = "has-background-link";
    public const string HasBackgroundPrimary = "has-background-primary";
    public const string HasBackgroundSuccess = "has-background-success";
    public const string HasBackgroundWarning = "has-background-warning";
    public const string HasBackgroundWhite = "has-background-white";

    public const string HasDropdown = "has-dropdown";
    public const string HasShadow = "has-shadow";
    public const string HasSkeleton = "has-skeleton";
    public const string HasTextBlack = "has-text-black";
    public const string HasTextDanger = "has-text-danger";
    public const string HasTextDark = "has-text-dark";
    public const string HasTextInfo = "has-text-info";
    public const string HasTextLight = "has-text-light";
    public const string HasTextLink = "has-text-link";
    public const string HasTextPrimary = "has-text-primary";
    public const string HasTextSuccess = "has-text-success";
    public const string HasTextWarning = "has-text-warning";
    public const string HasTextWhite = "has-text-white";

    public const string HasTextCentered = "has-text-centered";
    public const string HasTextJustified = "has-text-justified";
    public const string HasTextLeft = "has-text-left";
    public const string HasTextRight = "has-text-right";

    public const string Hero = "hero";
    public const string HeroBody = "hero-body";
    public const string HeroFooter = "hero-foot";
    public const string HeroHeader = "hero-head";
    public const string HeroTitle = "title";
    public const string HeroSubTitle = "subtitle";

    public const string Icon = "icon";
    public const string IconText = "icon-text";

    public const string Image = "image";

    public const string Input = "input";

    public const string Is1 = "is-1";
    public const string Is2 = "is-2";
    public const string Is3 = "is-3";
    public const string Is4 = "is-4";
    public const string Is5 = "is-5";
    public const string Is6 = "is-6";

    public const string Is16x16 = "is-16x16";
    public const string Is24x24 = "is-24x24";
    public const string Is32x32 = "is-32x32";
    public const string Is48x48 = "is-48x48";
    public const string Is64x64 = "is-64x64";
    public const string Is96x96 = "is-96x96";
    public const string Is128x128 = "is-128x128";

    public const string Is1by1 = "is-1by1";
    public const string Is5by4 = "is-5by4";
    public const string Is4by3 = "is-4by3";
    public const string Is3by2 = "is-3by2";
    public const string Is5by3 = "is-5by3";
    public const string Is16by9 = "is-16by9";
    public const string Is2by1 = "is-2by1";
    public const string Is3by1 = "is-3by1";
    public const string Is4by5 = "is-4by5";
    public const string Is3by4 = "is-3by4";
    public const string Is2by3 = "is-2by3";
    public const string Is3by5 = "is-3by5";
    public const string Is9by16 = "is-9by16";
    public const string Is1by2 = "is-1by2";
    public const string Is1by3 = "is-1by3";

    public const string IsActive = "is-active";
    public const string IsAlignContentBaseline = "is-align-content-baseline";
    public const string IsAlignContentCenter = "is-align-content-center";
    public const string IsAlignContentEnd = "is-align-content-end";
    public const string IsAlignContentFlexEnd = "is-align-content-flex-end";
    public const string IsAlignContentFlexStart = "is-align-content-flex-start";
    public const string IsAlignContentSpaceAround = "is-align-content-space-around";
    public const string IsAlignContentSpaceBetween = "is-align-content-space-between";
    public const string IsAlignContentSpaceEvenly = "is-align-content-space-evenly";
    public const string IsAlignContentStart = "is-align-content-start";
    public const string IsAlignContentStretch = "is-align-content-stretch";
    public const string IsBlack = "is-black";
    public const string IsBordered = "is-bordered";
    public const string IsBoxed = "is-boxed";
    public const string IsCentered = "is-centered";
    public const string IsCurrent = "is-current";
    public const string IsDanger = "is-danger";
    public const string IsDark = "is-dark";
    public const string IsDisabled = "is-disabled";
    public const string IsFlex = "is-flex";
    public const string IsFlexDirectionRow = "is-flex-direction-row";
    public const string IsFlexDirectionRowReverse = "is-flex-direction-row-reverse";
    public const string IsFlexDirectionColumn = "is-flex-direction-column";
    public const string IsFlexDirectionColumnReverse = "is-flex-direction-column-reverse";
    public const string IsFocused = "is-focused";
    public const string IsFullWidth = "is-fullwidth";
    public const string IsGhost = "is-ghost";
    public const string IsHidden = "is-hidden";
    public const string IsHoverable = "is-hoverable";
    public const string IsHovered = "is-hovered";
    public const string IsInfo = "is-info";
    public const string IsInverted = "is-inverted";
    public const string IsJustifyContentFlexStart = "is-justify-content-flex-start";
    public const string IsJustifyContentFlexEnd = "is-justify-content-flex-end";
    public const string IsJustifyContentCenter = "is-justify-content-center";
    public const string IsJustifyContentSpaceBetween = "is-justify-content-space-between";
    public const string IsJustifyContentSpaceAround = "is-justify-content-space-around";
    public const string IsJustifyContentSpaceEvenly = "is-justify-content-space-evenly";
    public const string IsJustifyContentStart = "is-justify-content-start";
    public const string IsJustifyContentEnd = "is-justify-content-end";
    public const string IsJustifyContentLeft = "is-justify-content-left";
    public const string IsJustifyContentRight = "is-justify-content-right";
    public const string IsLarge = "is-large";
    public const string IsLeft = "is-left";
    public const string IsLight = "is-light";
    public const string IsLink = "is-link";
    public const string IsLoading = "is-loading";
    public const string IsMedium = "is-medium";
    public const string IsMobile = "is-mobile";
    public const string IsNarrow = "is-narrow";
    public const string IsNormal = "is-normal";
    public const string IsOutlined = "is-outlined";
    public const string IsPrimary = "is-primary";
    public const string IsRight = "is-right";
    public const string IsRounded = "is-rounded";
    public const string IsScrollable = "is-scrollable";
    public const string IsSkeleton = "is-skeleton";
    public const string IsSmall = "is-small";
    public const string IsSpaced = "is-spaced";
    public const string IsSquare = "is-square";
    public const string IsStriped = "is-striped";
    public const string IsSuccess = "is-success";
    public const string IsText = "is-text";
    public const string IsToggle = "is-toggle";
    public const string IsToggleRounded = "is-toggle-rounded";
    public const string IsResponsive = "is-responsive";
    public const string IsWarning = "is-warning";
    public const string IsWhite = "is-white";

    public const string Menu = "menu";
    public const string MenuLabel = "menu-label";
    public const string MenuItem = "menu-item"; // custom class
    public const string MenuList = "menu-list";

    public const string Message = "message";
    public const string MessageBody = "message-body";
    public const string MessageHeader = "message-header";

    public const string Navbar = "navbar";
    public const string NavbarBrand = "navbar-brand";
    public const string NavbarBurger = "navbar-burger";
    public const string NavbarDivider = "navbar-divider";
    public const string NavbarDropdown = "navbar-dropdown";
    public const string NavbarEnd = "navbar-end";
    public const string NavbarItem = "navbar-item";
    public const string NavbarLink = "navbar-link";
    public const string NavbarMenu = "navbar-menu";
    public const string NavbarStart = "navbar-start";

    public const string Notification = "notification";

    public const string Overlay = "be-bulma-overlay";

    public const string Pagination = "pagination";
    public const string PaginationLink = "pagination-link";
    public const string PaginationList = "pagination-list";
    public const string PaginationNext = "pagination-next";
    public const string PaginationPrevious = "pagination-previous";

    public const string P5 = "p-5";

    public const string Reset = "reset";

    public const string Submit = "submit";
    public const string Section = "section";
    public const string SkeletonBlock = "skeleton-block";
    public const string SkeletonLines = "skeleton-lines";
    public const string SubTitle = "subtitle";

    public const string Table = "table";
    public const string TableContianer = "table-container";
    public const string Tabs = "tabs";
    public const string Title = "title";

    #endregion
}
