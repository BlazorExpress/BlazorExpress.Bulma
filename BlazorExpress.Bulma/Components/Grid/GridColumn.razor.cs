namespace BlazorExpress.Bulma;

public partial class GridColumn<TItem> : BulmaComponentBase
{
    internal SortDirection currentSortDirection;

    internal SortDirection defaultSortDirection;

    internal string SortIconName => GetSortIconName();

    internal string GetSortIconName()
    {
        if (currentSortDirection == SortDirection.Descending)
            return "bi bi-sort-alpha-down-alt";
        else if (currentSortDirection == SortDirection.Ascending)
            return "bi bi-sort-alpha-down";
        else
            return "bi bi-arrow-down-up"; // default icon
    }

    #region Methods

    protected override void OnInitialized()
    {
        Id ??= IdUtility.GetNextId();

        Console.WriteLine("GridColumn.OnInitialized() called");

        currentSortDirection = SortDirection;
        defaultSortDirection = SortDirection;

        if (IsDefaultSortColumn && SortDirection == SortDirection.None)
            currentSortDirection = SortDirection = SortDirection.Ascending;

        Parent.AddColumn(this);
        base.OnInitializedAsync();
    }

    #endregion

    internal bool CanSort() => Sortable && SortKeySelector is not null;

    internal IEnumerable<SortingItem<TItem>> GetSorting()
    {
        if (SortKeySelector == null && string.IsNullOrWhiteSpace(SortString))
            yield break;

        yield return new SortingItem<TItem>(SortString, SortKeySelector!, currentSortDirection);
    }

    #region Properties, Indexers

    [Parameter] public RenderFragment<TItem>? CellTemplate { get; set; }

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment<TItem>? ChildContent { get; set; }

    // using this member to access in the grid component
    internal string? GridColumnCssClassNames => Class;

    // using this member to access in the grid component
    internal string? GridColumnCssStyleNames => Style;

    [Parameter] public RenderFragment? HeaderTemplate { get; set; }

    /// <summary>
    /// Gets or sets the table column header text.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public string HeaderText { get; set; } = default!;

    /// <summary>
    /// Gets or sets the default sort column.
    /// </summary>
    /// <remarks>
    /// Default value is false.
    /// </remarks>
    [Parameter]
    public bool IsDefaultSortColumn { get; set; } = false;

    [CascadingParameter] public Grid<TItem> Parent { get; set; } = default!;

    /// <summary>
    /// Gets or sets the property name.
    /// This is required when `AllowFiltering` is true.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public string PropertyName { get; set; } = default!;

    internal string? ThClassNames => ThCssClass;

    [Parameter] public string? ThCssClass { get; set; }

    [Parameter] public string? ThCssStyle { get; set; }

    internal string? ThStyleNames => ThCssStyle;

    /// <summary>
    /// Enable or disable the sorting on a specific column.
    /// The sorting is enabled or disabled based on the `AllowSorting` parameter on the grid.
    /// </summary>
    /// <remarks>
    /// Default value is true.
    /// </remarks>
    [Parameter]
    public bool Sortable { get; set; } = true;

    /// <summary>
    /// Gets or sets the default sort direction of a column.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="SortDirection.None" />.
    /// </remarks>
    [Parameter]
    public SortDirection SortDirection { get; set; } = SortDirection.None;

    /// <summary>
    /// Expression used for sorting.
    /// </summary>
    [Parameter]
    public Expression<Func<TItem, IComparable>> SortKeySelector { get; set; } = default!;

    /// <summary>
    /// Gets or sets the column sort string.
    /// This value will be passed to the backend/API for sorting.
    /// And this property is ignored for the client-side sorting.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public string SortString { get; set; } = default!;

    /// <summary>
    /// Gets or sets the StringComparison.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="StringComparison.OrdinalIgnoreCase" />.
    /// </remarks>
    [Parameter]
    public StringComparison StringComparison { get; set; } = StringComparison.OrdinalIgnoreCase;

    #endregion
}
