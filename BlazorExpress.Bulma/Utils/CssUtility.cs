namespace BlazorExpress.Bulma;

public static class CssUtility
{
    public static string? BuildClassNames(string? userDefinedClassName, params (string? className, bool condition)[] classNames)
    {
        if (!(classNames?.Any() ?? false) && string.IsNullOrWhiteSpace(userDefinedClassName))
            return null;

        var classList = new HashSet<string>();

        if (classNames?.Any() ?? false)
            foreach (var (className, condition) in classNames)
            {
                if (!string.IsNullOrWhiteSpace(className) && condition)
                    classList.Add(className!);
            }

        if (!string.IsNullOrWhiteSpace(userDefinedClassName))
            classList.Add(userDefinedClassName!.Trim());

        return string.Join(" ", classList);
    }

    public static string? BuildStyleNames(string? userDefinedStyle, params (string? style, bool condition)[] styles)
    {
        if (!(styles?.Any() ?? false) && string.IsNullOrWhiteSpace(userDefinedStyle))
            return null;

        var styleList = new HashSet<string>();

        if (styles?.Any() ?? false)
            foreach (var (style, condition) in styles)
            {
                if (!string.IsNullOrWhiteSpace(style) && condition)
                    styleList.Add(style!);
            }

        if (!string.IsNullOrWhiteSpace(userDefinedStyle))
            styleList.Add(userDefinedStyle!.Trim());

        return string.Join(";", styleList);
    }
}
