namespace BlazorExpress.Bulma;

public class GridState<TItem>
{
    #region Constructors

    public GridState(int pageNumber, int pageSize, IEnumerable<SortingItem<TItem>>? sorting)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Sorting = sorting;
    }

    #endregion

    #region Properties, Indexers

    /// <summary>
    /// Current page number.
    /// </summary>
    public int PageNumber { get; }

    /// <summary>
    /// Current page size.
    /// </summary>
    public int PageSize { get; }

    /// <summary>
    /// Current sorting.
    /// </summary>
    public IEnumerable<SortingItem<TItem>>? Sorting { get; }

    #endregion
}
