namespace BlazorExpress.Bulma;

public static class GoogleFontIconUtility
{
    #region Methods

    /// <summary>
    /// The prefix for all google font icons.
    /// </summary>
    public static string Icon()
    {
        return "material-symbols";
    }

    /// <summary>
    /// Returns the CSS class for the specified icon.
    /// </summary>
    /// <param name="style"></param>
    /// <returns></returns>
    public static string Icon(GoogleFontIconStyle style)
    {
        return $"{Icon()}-{ToIconStyleName(style)}";
    }

    /// <summary>
    /// Converts an icon style to its corresponding CSS class name.
    /// </summary>
    /// <param name="style"></param>
    /// <returns></returns>
    public static string ToIconStyleName(GoogleFontIconStyle style)
    {
        return style switch
        {
            GoogleFontIconStyle.Outlined => "outlined",
            GoogleFontIconStyle.Rounded => "rounded",
            GoogleFontIconStyle.Sharp => "sharp",

            _ => ""
        };
    }

    /// <summary>
    /// Returns the name of the specified icon.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string ToIconName(GoogleFontIconName name)
    {
        return name switch
        {
            GoogleFontIconName.Rotation3D => "3d_rotation",
            GoogleFontIconName.Accessibility => "accessibility",
            GoogleFontIconName.AccessibilityNew => "accessibility_new",
            GoogleFontIconName.Accessible => "accessible",
            GoogleFontIconName.AccessibleForward => "accessible_forward",
            GoogleFontIconName.AccountBox => "account_box",
            GoogleFontIconName.AccountCircle => "account_circle",
            GoogleFontIconName.AccountCircleOff => "account_circle_off",
            GoogleFontIconName.Ad => "ad",
            GoogleFontIconName.AdGroup => "ad_group",
            GoogleFontIconName.AdGroupOff => "ad_group_off",
            GoogleFontIconName.AdOff => "ad_off",
            GoogleFontIconName.AddAlert => "add_alert",
            GoogleFontIconName.AdsClick => "ads_click",
            GoogleFontIconName.Alarm => "alarm",
            GoogleFontIconName.AlarmAdd => "alarm_add",
            GoogleFontIconName.AlarmOff => "alarm_off",
            GoogleFontIconName.AlarmOn => "alarm_on",
            GoogleFontIconName.AllInclusive => "all_inclusive",
            GoogleFontIconName.AllOut => "all_out",
            GoogleFontIconName.Anchor => "anchor",
            GoogleFontIconName.Api => "api",
            GoogleFontIconName.AppShortcut => "app_shortcut",
            GoogleFontIconName.Approval => "approval",
            GoogleFontIconName.AutoDelete => "auto_delete",
            GoogleFontIconName.AwardStar => "award_star",
            GoogleFontIconName.BackgroundReplace => "background_replace",
            GoogleFontIconName.Backup => "backup",
            GoogleFontIconName.BackupTable => "backup_table",
            GoogleFontIconName.BatchPrediction => "batch_prediction",
            GoogleFontIconName.BookmarkAdd => "bookmark_add",
            GoogleFontIconName.BookmarkAdded => "bookmark_added",
            GoogleFontIconName.BookmarkBag => "bookmark_bag",
            GoogleFontIconName.BookmarkCheck => "bookmark_check",
            GoogleFontIconName.BookmarkFlag => "bookmark_flag",
            GoogleFontIconName.BookmarkHeart => "bookmark_heart",
            GoogleFontIconName.BookmarkStar => "bookmark_star",
            GoogleFontIconName.Bookmarks => "bookmarks",
            GoogleFontIconName.Browse => "browse",
            GoogleFontIconName.BugReport => "bug_report",
            GoogleFontIconName.Build => "build",
            GoogleFontIconName.BuildCircle => "build_circle",
            GoogleFontIconName.CalendarToday => "calendar_today",
            GoogleFontIconName.Category => "category",
            GoogleFontIconName.Celebration => "celebration",
            GoogleFontIconName.ChangeHistory => "change_history",
            GoogleFontIconName.ChromeReaderMode => "chrome_reader_mode",
            GoogleFontIconName.CircleNotifications => "circle_notifications",
            GoogleFontIconName.Code => "code",
            GoogleFontIconName.CodeBlocks => "code_blocks",
            GoogleFontIconName.CodeOff => "code_off",
            GoogleFontIconName.CollectionsBookmark => "collections_bookmark",
            GoogleFontIconName.Commit => "commit",
            GoogleFontIconName.ComponentExchange => "component_exchange",
            GoogleFontIconName.DataLossPrevention => "data_loss_prevention",
            GoogleFontIconName.DateRange => "date_range",
            GoogleFontIconName.DeleteHistory => "delete_history",
            GoogleFontIconName.DeveloperGuide => "developer_guide",
            GoogleFontIconName.DomainVerification => "domain_verification",
            GoogleFontIconName.DomainVerificationOff => "domain_verification_off",
            GoogleFontIconName.EditCalendar => "edit_calendar",
            GoogleFontIconName.EditNotifications => "edit_notifications",
            GoogleFontIconName.EditSquare => "edit_square",
            GoogleFontIconName.Error => "error",
            GoogleFontIconName.Event => "event",
            GoogleFontIconName.EventAvailable => "event_available",
            GoogleFontIconName.EventRepeat => "event_repeat",
            GoogleFontIconName.EventUpcoming => "event_upcoming",
            GoogleFontIconName.Extension => "extension",
            GoogleFontIconName.FeatureSearch => "feature_search",
            GoogleFontIconName.Feedback => "feedback",
            GoogleFontIconName.FindReplace => "find_replace",
            GoogleFontIconName.Flutter => "flutter",
            GoogleFontIconName.FlutterDash => "flutter_dash",
            GoogleFontIconName.FreeCancellation => "free_cancellation",
            GoogleFontIconName.Search => "search",

            _ => ""
        };
    }

    #endregion
}
