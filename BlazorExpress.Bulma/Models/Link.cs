namespace BlazorExpress.Bulma;

public class Link
{
    #region Properties, Indexers

    public string? Href { get; set; }
    public HashSet<Link>? Links { get; set; }
    public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;
    public string? Text { get; set; }

    #endregion
}
