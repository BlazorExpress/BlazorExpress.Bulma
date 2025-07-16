namespace BlazorExpress.Bulma.Docx;

/// <summary>
/// Extension methods for <see cref="Enum" />.
/// </summary>
public static class EnumExtensions
{
    public static string? ToLanguageCssClass(this LanguageCode languageCode) =>
        languageCode switch
        {
            LanguageCode.AspNet => "language-aspnet",
            LanguageCode.CSharp => "language-csharp",
            LanguageCode.Css => "language-csharp",
            LanguageCode.HTML => "language-html",
            LanguageCode.JavaScript => "language-js",
            LanguageCode.JSON => "language-json",
            LanguageCode.JSONP => "language-jsonp",
            LanguageCode.Markdown => "language-md",
            LanguageCode.PowerShell => "language-powershell",
            LanguageCode.Razor => "language-razor",
            LanguageCode.Text => "language-none",
            LanguageCode.YAML => "language-yaml",
            _ => null
        };

    public static string? ToLanguageName(this LanguageCode languageCode) =>
        languageCode switch
        {
            LanguageCode.AspNet => "ASP.NET",
            LanguageCode.CSharp => "C#",
            LanguageCode.Css => "CSS",
            LanguageCode.HTML => "HTML",
            LanguageCode.JavaScript => "JS",
            LanguageCode.JSON => "Json",
            LanguageCode.JSONP => "Jsonp",
            LanguageCode.Markdown => "Markdown",
            LanguageCode.PowerShell => "PowerShell",
            LanguageCode.Razor => "Razor",
            LanguageCode.Text => "Text",
            LanguageCode.YAML => "Yaml",
            _ => null
        };
}
