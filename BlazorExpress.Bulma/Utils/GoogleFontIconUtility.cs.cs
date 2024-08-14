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
            GoogleFontIconName.Search => "search",

            _ => ""
        };
    }

    #endregion
}
