namespace BlazorExpress.Bulma;

public class Link
{
    #region Properties, Indexers

    public string? Href { get; set; }
    public HashSet<Link>? Links { get; set; }
    public MenuItemMatch Match { get; set; } = MenuItemMatch.Prefix;
    public string? Text { get; set; }

    #endregion
}
