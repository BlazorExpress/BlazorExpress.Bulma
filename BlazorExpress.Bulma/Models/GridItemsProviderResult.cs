namespace BlazorExpress.Bulma;

public class GridItemsProviderResult<TItem>
{
    public required IEnumerable<TItem> Items { get; init; }

    public int Count { get; init; }
}
