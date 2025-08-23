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
            GoogleFontIconName.Abc => "abc",
            GoogleFontIconName.AcUnit => "ac_unit",
            GoogleFontIconName.Accessibility => "accessibility",
            GoogleFontIconName.AccessibilityNew => "accessibility_new",
            GoogleFontIconName.Accessible => "accessible",
            GoogleFontIconName.AccessibleForward => "accessible_forward",
            GoogleFontIconName.AccessibleMenu => "accessible_menu",
            GoogleFontIconName.AccountBalance => "account_balance",
            GoogleFontIconName.AccountBalanceWallet => "account_balance_wallet",
            GoogleFontIconName.AccountBox => "account_box",
            GoogleFontIconName.AccountChild => "account_child",
            GoogleFontIconName.AccountChildInvert => "account_child_invert",
            GoogleFontIconName.AccountCircle => "account_circle",
            GoogleFontIconName.AccountCircleOff => "account_circle_off",
            GoogleFontIconName.AccountTree => "account_tree",
            GoogleFontIconName.ActionKey => "action_key",
            GoogleFontIconName.ActivityZone => "activity_zone",
            GoogleFontIconName.Acupuncture => "acupuncture",
            GoogleFontIconName.Acute => "acute",
            GoogleFontIconName.Ad => "ad",
            GoogleFontIconName.AdGroup => "ad_group",
            GoogleFontIconName.AdGroupOff => "ad_group_off",
            GoogleFontIconName.AdOff => "ad_off",
            GoogleFontIconName.AdaptiveAudioMic => "adaptive_audio_mic",
            GoogleFontIconName.AdaptiveAudioMicOff => "adaptive_audio_mic_off",
            GoogleFontIconName.Adb => "adb",
            GoogleFontIconName.AddAlert => "add_alert",
            GoogleFontIconName.AddColumnLeft => "add_column_left",
            GoogleFontIconName.AddColumnRight => "add_column_right",
            GoogleFontIconName.AddLocationAlt => "add_location_alt",
            GoogleFontIconName.AddShoppingCart => "add_shopping_cart",
            GoogleFontIconName.Adjust => "adjust",
            GoogleFontIconName.AlignFlexCenter => "align_flex_center",
            GoogleFontIconName.AlignFlexEnd => "align_flex_end",
            GoogleFontIconName.AlignFlexStart => "align_flex_start",
            GoogleFontIconName.AlignHorizontalCenter => "align_horizontal_center",
            GoogleFontIconName.AlignHorizontalLeft => "align_horizontal_left",
            GoogleFontIconName.AlignHorizontalRight => "align_horizontal_right",
            GoogleFontIconName.AlignJustifyCenter => "align_justify_center",
            GoogleFontIconName.AlignJustifyFlexEnd => "align_justify_flex_end",
            GoogleFontIconName.AlignJustifyFlexStart => "align_justify_flex_start",
            GoogleFontIconName.AlignJustifySpaceBetween => "align_justify_space_between",
            GoogleFontIconName.AlignVerticalBottom => "align_vertical_bottom",
            GoogleFontIconName.AlignVerticalCenter => "align_vertical_center",
            GoogleFontIconName.AlignVerticalTop => "align_vertical_top",
            GoogleFontIconName.AllInclusive => "all_inclusive",
            GoogleFontIconName.AllOut => "all_out",
            GoogleFontIconName.Anchor => "anchor",
            GoogleFontIconName.Api => "api",
            GoogleFontIconName.Approval => "approval",
            GoogleFontIconName.ArrowBackIos => "arrow_back_ios",
            GoogleFontIconName.ArrowBackIosNew => "arrow_back_ios_new",
            GoogleFontIconName.ArrowCircleLeft => "arrow_circle_left",
            GoogleFontIconName.ArrowCircleRight => "arrow_circle_right",
            GoogleFontIconName.ArrowDownwardAlt => "arrow_downward_alt",
            GoogleFontIconName.ArrowDropDownCircle => "arrow_drop_down_circle",
            GoogleFontIconName.ArrowForwardIos => "arrow_forward_ios",
            GoogleFontIconName.ArrowLeftAlt => "arrow_left_alt",
            GoogleFontIconName.ArrowMenuClose => "arrow_menu_close",
            GoogleFontIconName.ArrowMenuOpen => "arrow_menu_open",
            GoogleFontIconName.ArrowRightAlt => "arrow_right_alt",
            GoogleFontIconName.ArrowSelectorTool => "arrow_selector_tool",
            GoogleFontIconName.ArrowShapeUpStack => "arrow_shape_up_stack",
            GoogleFontIconName.ArrowTopLeft => "arrow_top_left",
            GoogleFontIconName.ArrowTopRight => "arrow_top_right",
            GoogleFontIconName.ArrowUpwardAlt => "arrow_upward_alt",
            GoogleFontIconName.AutoAwesomeMotion => "auto_awesome_motion",
            GoogleFontIconName.AutoDelete => "auto_delete",
            GoogleFontIconName.AutoReadPlay => "auto_read_play",
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
            GoogleFontIconName.BottomAppBar => "bottom_app_bar",
            GoogleFontIconName.BottomPanelClose => "bottom_panel_close",
            GoogleFontIconName.BottomPanelOpen => "bottom_panel_open",
            GoogleFontIconName.Browse => "browse",
            GoogleFontIconName.BugReport => "bug_report",
            GoogleFontIconName.Build => "build",
            GoogleFontIconName.BuildCircle => "build_circle",
            GoogleFontIconName.CalendarToday => "calendar_today",
            GoogleFontIconName.CarDefrostLeft => "car_defrost_left",
            GoogleFontIconName.CarDefrostLowLeft => "car_defrost_low_left",
            GoogleFontIconName.CarDefrostLowRight => "car_defrost_low_right",
            GoogleFontIconName.CarDefrostMidLeft => "car_defrost_mid_left",
            GoogleFontIconName.CarDefrostMidLowLeft => "car_defrost_mid_low_left",
            GoogleFontIconName.CarDefrostMidLowRight => "car_defrost_mid_low_right",
            GoogleFontIconName.CarDefrostMidRight => "car_defrost_mid_right",
            GoogleFontIconName.CarDefrostRight => "car_defrost_right",
            GoogleFontIconName.CarFanLowLeft => "car_fan_low_left",
            GoogleFontIconName.CarFanLowMidLeft => "car_fan_low_mid_left",
            GoogleFontIconName.CarFanLowRight => "car_fan_low_right",
            GoogleFontIconName.CarFanMidLeft => "car_fan_mid_left",
            GoogleFontIconName.CarFanMidLowRight => "car_fan_mid_low_right",
            GoogleFontIconName.CarFanMidRight => "car_fan_mid_right",
            GoogleFontIconName.CarMirrorHeat => "car_mirror_heat",
            GoogleFontIconName.Category => "category",
            GoogleFontIconName.Celebration => "celebration",
            GoogleFontIconName.ChangeHistory => "change_history",
            GoogleFontIconName.ChatPasteGo => "chat_paste_go",
            GoogleFontIconName.CheckCircleUnread => "check_circle_unread",
            GoogleFontIconName.ChromeReaderMode => "chrome_reader_mode",
            GoogleFontIconName.CircleNotifications => "circle_notifications",
            GoogleFontIconName.Code => "code",
            GoogleFontIconName.CodeBlocks => "code_blocks",
            GoogleFontIconName.CodeOff => "code_off",
            GoogleFontIconName.CollectionsBookmark => "collections_bookmark",
            GoogleFontIconName.Commit => "commit",
            GoogleFontIconName.ComponentExchange => "component_exchange",
            GoogleFontIconName.Computer => "computer",
            GoogleFontIconName.CurrencyRupeeCircle => "currency_rupee_circle",
            GoogleFontIconName.DataInfoAlert => "data_info_alert",
            GoogleFontIconName.DataLossPrevention => "data_loss_prevention",
            GoogleFontIconName.DateRange => "date_range",
            GoogleFontIconName.DeleteHistory => "delete_history",
            GoogleFontIconName.DeveloperGuide => "developer_guide",
            GoogleFontIconName.DisplayExternalInput => "display_external_input",
            GoogleFontIconName.DomainVerification => "domain_verification",
            GoogleFontIconName.DomainVerificationOff => "domain_verification_off",
            GoogleFontIconName.DriveFileMove => "drive_file_move",
            GoogleFontIconName.DriveFolderUpload => "drive_folder_upload",
            GoogleFontIconName.EditCalendar => "edit_calendar",
            GoogleFontIconName.EditLocationAlt => "edit_location_alt",
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
            GoogleFontIconName.FileMapStack => "file_map_stack",
            GoogleFontIconName.FindReplace => "find_replace",
            GoogleFontIconName.Flutter => "flutter",
            GoogleFontIconName.FlutterDash => "flutter_dash",
            GoogleFontIconName.FramePersonMic => "frame_person_mic",
            GoogleFontIconName.FreeCancellation => "free_cancellation",
            GoogleFontIconName.FullStackedBarChart => "full_stacked_bar_chart",
            GoogleFontIconName.Gesture => "gesture",
            GoogleFontIconName.GestureSelect => "gesture_select",
            GoogleFontIconName.GoogleHomeDevices => "google_home_devices",
            GoogleFontIconName.GoogleTvRemote => "google_tv_remote",
            GoogleFontIconName.GoogleWifi => "google_wifi",
            GoogleFontIconName.HandGesture => "hand_gesture",
            GoogleFontIconName.HeatPumpBalance => "heat_pump_balance",
            GoogleFontIconName.HelpCenter => "help_center",
            GoogleFontIconName.HelpClinic => "help_clinic",
            GoogleFontIconName.History => "history",
            GoogleFontIconName.History2 => "history_2",
            GoogleFontIconName.HistoryOff => "history_off",
            GoogleFontIconName.HistoryToggleOff => "history_toggle_off",
            GoogleFontIconName.Home => "home",
            GoogleFontIconName.HomeIotDevice => "home_iot_device",
            GoogleFontIconName.Hourglass => "hourglass",
            GoogleFontIconName.HourglassDisabled => "hourglass_disabled",
            GoogleFontIconName.HourglassEmpty => "hourglass_empty",
            GoogleFontIconName.HourglassPause => "hourglass_pause",
            GoogleFontIconName.InactiveOrder => "inactive_order",
            GoogleFontIconName.IndeterminateCheckBox => "indeterminate_check_box",
            GoogleFontIconName.IndeterminateQuestionBox => "indeterminate_question_box",
            GoogleFontIconName.InkHighlighterMove => "ink_highlighter_move",
            GoogleFontIconName.KeyboardArrowLeft => "keyboard_arrow_left",
            GoogleFontIconName.KeyboardArrowRight => "keyboard_arrow_right",
            GoogleFontIconName.KeyboardCommandKey => "keyboard_command_key",
            GoogleFontIconName.KeyboardControlKey => "keyboard_control_key",
            GoogleFontIconName.KeyboardDoubleArrowDown => "keyboard_double_arrow_down",
            GoogleFontIconName.KeyboardDoubleArrowLeft => "keyboard_double_arrow_left",
            GoogleFontIconName.KeyboardDoubleArrowRight => "keyboard_double_arrow_right",
            GoogleFontIconName.KeyboardDoubleArrowUp => "keyboard_double_arrow_up",
            GoogleFontIconName.KeyboardExternalInput => "keyboard_external_input",
            GoogleFontIconName.KeyboardOptionKey => "keyboard_option_key",
            GoogleFontIconName.KeyboardTabRtl => "keyboard_tab_rtl",
            GoogleFontIconName.LeftPanelClose => "left_panel_close",
            GoogleFontIconName.LeftPanelOpen => "left_panel_open",
            GoogleFontIconName.LineEndArrow => "line_end_arrow",
            GoogleFontIconName.LineEndCircle => "line_end_circle",
            GoogleFontIconName.LineStartArrow => "line_start_arrow",
            GoogleFontIconName.LineStartCircle => "line_start_circle",
            GoogleFontIconName.ListAltAdd => "list_alt_add",
            GoogleFontIconName.ListAltCheck => "list_alt_check",
            GoogleFontIconName.LockOpenCircle => "lock_open_circle",
            GoogleFontIconName.LockOpenRight => "lock_open_right",
            GoogleFontIconName.More => "more",
            GoogleFontIconName.NestHeatLinkE => "nest_heat_link_e",
            GoogleFontIconName.NestRemoteComfortSensor => "nest_remote_comfort_sensor",
            GoogleFontIconName.OrderApprove => "order_approve",
            GoogleFontIconName.OrderPlay => "order_play",
            GoogleFontIconName.Search => "search",
            GoogleFontIconName.Sort => "sort",
            GoogleFontIconName.SortByAlpha => "sort_by_alpha",
            GoogleFontIconName.TextSelectJumpToEnd => "text_select_jump_to_end",
            GoogleFontIconName.TextSelectMoveBackCharacter => "text_select_move_back_character",
            GoogleFontIconName.TextSelectMoveBackWord => "text_select_move_back_word",
            GoogleFontIconName.TextSelectMoveForwardCharacter => "text_select_move_forward_character",
            GoogleFontIconName.TextSelectMoveForwardWord => "text_select_move_forward_word",
            GoogleFontIconName.ThumbUp => "thumb_up",
            GoogleFontIconName.ThreeDRotation => "3d_rotation",
            GoogleFontIconName.TvOptionsInputSettings => "tv_options_input_settings",
            GoogleFontIconName.VideoCameraBackAdd => "video_camera_back_add",

            _ => ""
        };
    }

    #endregion
}
