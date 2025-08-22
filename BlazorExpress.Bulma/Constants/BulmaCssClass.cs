namespace BlazorExpress.Bulma;

public static class BulmaCssClass
{
    #region Fields and Constants

    public const string AreSmall = "are-small";
    public const string AreMedium = "are-medium";
    public const string AreLarge = "are-large";

    public const string Block = "block";

    public const string Breadcrumb = "breadcrumb";

    public const string Box = "box";

    public const string Button = "button";
    public const string Buttons = "buttons";

    public const string Card = "card";

    public const string Control = "control";

    public const string Delete = "delete";

    public const string Dropdown = "dropdown";
    public const string DropdownContent = "dropdown-content";
    public const string DropdownDivider = "dropdown-divider";
    public const string DropdownItem = "dropdown-item";
    public const string DropdownMenu = "dropdown-menu";
    public const string DropdownTrigger = "dropdown-trigger";

    public const string Field = "field";

    public const string HasAddons = "has-addons";

    public const string HasArrowSeparator = "has-arrow-separator";

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

    public const string HasBulletSeparator = "has-bullet-separator";

    public const string HasDropdown = "has-dropdown";

    public const string HasDotSeparator = "has-dot-separator";

    public const string HasShadow = "has-shadow";

    public const string HasSkeleton = "has-skeleton";

    public const string HasSucceedsSeparator = "has-succeeds-separator";

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
    public const string IsDelete = "is-delete";
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
    public const string IsGrouped = "is-grouped";
    public const string IsGroupedMultiline = "is-grouped-multiline";
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
    public const string IsMultiple = "is-multiple";
    public const string IsNarrow = "is-narrow";
    public const string IsNormal = "is-normal";
    public const string IsOutlined = "is-outlined";
    public const string IsPrimary = "is-primary";
    public const string IsRight = "is-right";
    public const string IsRounded = "is-rounded";
    public const string IsScrollable = "is-scrollable";
    public const string IsSize1 = "is-size-1";
    public const string IsSize2 = "is-size-2";
    public const string IsSize3 = "is-size-3";
    public const string IsSize4 = "is-size-4";
    public const string IsSize5 = "is-size-5";
    public const string IsSize6 = "is-size-6";
    public const string IsSize7 = "is-size-7";
    public const string IsSkeleton = "is-skeleton";
    public const string IsSmall = "is-small";
    public const string IsSoft = "is-soft";
    public const string IsSpaced = "is-spaced";
    public const string IsSquare = "is-square";
    public const string IsStriped = "is-striped";
    public const string IsSuccess = "is-success";
    public const string IsText = "is-text";
    public const string IsToggle = "is-toggle";
    public const string IsToggleRounded = "is-toggle-rounded";
    public const string IsTransparent = "is-transparent";
    public const string IsResponsive = "is-responsive";
    public const string IsWarning = "is-warning";
    public const string IsWhite = "is-white";

    public const string Margin0 = "m-0";
    public const string Margin1 = "m-1";
    public const string Margin2 = "m-2";
    public const string Margin3 = "m-3";
    public const string Margin4 = "m-4";
    public const string Margin5 = "m-5";
    public const string Margin6 = "m-6";
    public const string MarginAuto = "m-auto";

    public const string MarginBottom0 = "mb-0";
    public const string MarginBottom1 = "mb-1";
    public const string MarginBottom2 = "mb-2";
    public const string MarginBottom3 = "mb-3";
    public const string MarginBottom4 = "mb-4";
    public const string MarginBottom5 = "mb-5";
    public const string MarginBottom6 = "mb-6";
    public const string MarginBottomAuto = "mb-auto";

    public const string MarginLeft0 = "ml-0";
    public const string MarginLeft1 = "ml-1";
    public const string MarginLeft2 = "ml-2";
    public const string MarginLeft3 = "ml-3";
    public const string MarginLeft4 = "ml-4";
    public const string MarginLeft5 = "ml-5";
    public const string MarginLeft6 = "ml-6";
    public const string MarginLeftAuto = "ml-auto";

    public const string MarginLeftRight0 = "mx-0";
    public const string MarginLeftRight1 = "mx-1";
    public const string MarginLeftRight2 = "mx-2";
    public const string MarginLeftRight3 = "mx-3";
    public const string MarginLeftRight4 = "mx-4";
    public const string MarginLeftRight5 = "mx-5";
    public const string MarginLeftRight6 = "mx-6";
    public const string MarginLeftRightAuto = "mx-auto";

    public const string MarginRight0 = "mr-0";
    public const string MarginRight1 = "mr-1";
    public const string MarginRight2 = "mr-2";
    public const string MarginRight3 = "mr-3";
    public const string MarginRight4 = "mr-4";
    public const string MarginRight5 = "mr-5";
    public const string MarginRight6 = "mr-6";
    public const string MarginRightAuto = "mr-auto";

    public const string MarginTop0 = "mt-0";
    public const string MarginTop1 = "mt-1";
    public const string MarginTop2 = "mt-2";
    public const string MarginTop3 = "mt-3";
    public const string MarginTop4 = "mt-4";
    public const string MarginTop5 = "mt-5";
    public const string MarginTop6 = "mt-6";
    public const string MarginTopAuto = "mt-auto";

    public const string MarginTopBottom0 = "my-0";
    public const string MarginTopBottom1 = "my-1";
    public const string MarginTopBottom2 = "my-2";
    public const string MarginTopBottom3 = "my-3";
    public const string MarginTopBottom4 = "my-4";
    public const string MarginTopBottom5 = "my-5";
    public const string MarginTopBottom6 = "my-6";
    public const string MarginTopBottomAuto = "my-auto";

    public const string Menu = "menu";
    public const string MenuLabel = "menu-label";
    public const string MenuItem = "menu-item"; // custom class
    public const string MenuList = "menu-list";

    public const string Message = "message";
    public const string MessageBody = "message-body";
    public const string MessageHeader = "message-header";

    public const string Modal = "modal";
    public const string ModalBackground = "modal-background";
    public const string ModalCard = "modal-card";
    public const string ModalCardHead = "modal-card-head";
    public const string ModalCardTitle = "modal-card-title";
    public const string ModalCardBody = "modal-card-body";
    public const string ModalCardFoot = "modal-card-foot";
    public const string ModalClose = "modal-close";
    public const string ModalContent = "modal-content";

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

    public const string Padding0 = "p-0";
    public const string Padding1 = "p-1";
    public const string Padding2 = "p-2";
    public const string Padding3 = "p-3";
    public const string Padding4 = "p-4";
    public const string Padding5 = "p-5";
    public const string Padding6 = "p-6";
    public const string PaddingAuto = "p-auto";

    public const string PaddingBottom0 = "pb-0";
    public const string PaddingBottom1 = "pb-1";
    public const string PaddingBottom2 = "pb-2";
    public const string PaddingBottom3 = "pb-3";
    public const string PaddingBottom4 = "pb-4";
    public const string PaddingBottom5 = "pb-5";
    public const string PaddingBottom6 = "pb-6";
    public const string PaddingBottomAuto = "pb-auto";

    public const string PaddingLeft0 = "pl-0";
    public const string PaddingLeft1 = "pl-1";
    public const string PaddingLeft2 = "pl-2";
    public const string PaddingLeft3 = "pl-3";
    public const string PaddingLeft4 = "pl-4";
    public const string PaddingLeft5 = "pl-5";
    public const string PaddingLeft6 = "pl-6";
    public const string PaddingLeftAuto = "pl-auto";

    public const string PaddingLeftRight0 = "px-0";
    public const string PaddingLeftRight1 = "px-1";
    public const string PaddingLeftRight2 = "px-2";
    public const string PaddingLeftRight3 = "px-3";
    public const string PaddingLeftRight4 = "px-4";
    public const string PaddingLeftRight5 = "px-5";
    public const string PaddingLeftRight6 = "px-6";
    public const string PaddingLeftRightAuto = "px-auto";

    public const string PaddingRight0 = "pr-0";
    public const string PaddingRight1 = "pr-1";
    public const string PaddingRight2 = "pr-2";
    public const string PaddingRight3 = "pr-3";
    public const string PaddingRight4 = "pr-4";
    public const string PaddingRight5 = "pr-5";
    public const string PaddingRight6 = "pr-6";
    public const string PaddingRightAuto = "pr-auto";

    public const string PaddingTop0 = "pt-0";
    public const string PaddingTop1 = "pt-1";
    public const string PaddingTop2 = "pt-2";
    public const string PaddingTop3 = "pt-3";
    public const string PaddingTop4 = "pt-4";
    public const string PaddingTop5 = "pt-5";
    public const string PaddingTop6 = "pt-6";
    public const string PaddingTopAuto = "pt-auto";

    public const string PaddingTopBottom0 = "py-0";
    public const string PaddingTopBottom1 = "py-1";
    public const string PaddingTopBottom2 = "py-2";
    public const string PaddingTopBottom3 = "py-3";
    public const string PaddingTopBottom4 = "py-4";
    public const string PaddingTopBottom5 = "py-5";
    public const string PaddingTopBottom6 = "py-6";
    public const string PaddingTopBottomAuto = "py-auto";

    public const string Pagination = "pagination";
    public const string PaginationLink = "pagination-link";
    public const string PaginationList = "pagination-list";
    public const string PaginationNext = "pagination-next";
    public const string PaginationPrevious = "pagination-previous";

    public const string Progress = "progress";

    public const string P5 = "p-5";

    public const string Reset = "reset";

    public const string Select = "select";

    public const string Submit = "submit";
    public const string Section = "section";
    public const string SkeletonBlock = "skeleton-block";
    public const string SkeletonLines = "skeleton-lines";
    public const string SubTitle = "subtitle";

    public const string Table = "table";
    public const string TableContianer = "table-container";
    public const string Tabs = "tabs";

    public const string Tag = "tag";
    public const string Tags = "tags";

    public const string Title = "title";

    #endregion
}
