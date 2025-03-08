namespace BlazorExpress.Bulma;

public class GridDataProviderResult<TItem>
{
    #region Properties, Indexers

    /// <summary>
    /// The provided items by the request.
    /// <para>
    /// Default value is null.
    /// </para>
    /// </summary>
    public required IEnumerable<TItem> Data { get; init; }

    /// <summary>
    /// The total item count in the source (for pagination and infinite scroll).
    /// <para>
    /// Default value is null.
    /// </para>
    /// </summary>
    public int TotalCount { get; init; }

    #endregion
}
