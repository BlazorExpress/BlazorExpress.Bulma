namespace BlazorExpress.Bulma;

public partial class GridColumn<TItem> : BulmaComponentBase
{
    #region Fields and Constants

    internal SortDirection currentSortDirection;

    internal SortDirection defaultSortDirection;

    #endregion

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

    internal bool CanSort() => Sortable && SortKeySelector is not null;

    internal string GetSortIconName()
    {
        if (currentSortDirection == SortDirection.Ascending)
            return "bi bi-sort-alpha-down";

        if (currentSortDirection == SortDirection.Descending)
            return "bi bi-sort-alpha-down-alt";

        return "bi bi-arrow-down-up"; // default icon
    }

    internal IEnumerable<SortingItem<TItem>> GetSorting()
    {
        if (SortKeySelector is null && string.IsNullOrWhiteSpace(SortString))
            yield break;

        yield return new SortingItem<TItem>(SortString, SortKeySelector!, currentSortDirection);
    }

    #endregion

    #region Properties, Indexers

    /// <summary>
    /// Gets or sets the cell template.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the cell template.")]
    [ParameterTypeName("RenderFragment<TItem>?")]
    [Parameter] public RenderFragment<TItem>? CellTemplate { get; set; }

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [ParameterTypeName("RenderFragment<TItem>?")]
    [Parameter]
    [EditorRequired]
    public RenderFragment<TItem>? ChildContent { get; set; }

    // using this member to access in the grid component
    internal string? GridColumnCssClassNames => Class;

    // using this member to access in the grid component
    internal string? GridColumnCssStyleNames => Style;

    /// <summary>
    /// Gets or sets the header template.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the header template.")]
    [Parameter] public RenderFragment? HeaderTemplate { get; set; }

    /// <summary>
    /// Gets or sets the table column header text.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the table column header text.")]
    [Parameter]
    public string HeaderText { get; set; } = default!;

    /// <summary>
    /// Gets or sets the default sort column.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the default sort column.")]
    [Parameter]
    public bool IsDefaultSortColumn { get; set; } = false;
    
    [CascadingParameter] 
    public Grid<TItem> Parent { get; set; } = default!;

    /// <summary>
    /// Gets or sets the property name.
    /// This is required when `AllowFiltering` is true.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the property name. This is required when <code>AllowFiltering</code> is <b>true</b>.")]
    [Parameter]
    public string PropertyName { get; set; } = default!;

    /// <summary>
    /// Enable or disable the sorting on a specific column.
    /// The sorting is enabled or disabled based on the `AllowSorting` parameter on the grid.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="true"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(true)]
    [Description("Enable or disable the sorting on a specific column. The sorting is enabled or disabled based on the <code>AllowSorting</code> parameter on the grid.")]
    [Parameter]
    public bool Sortable { get; set; } = true;

    /// <summary>
    /// Gets or sets the default sort direction of a column.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="SortDirection.None" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(SortDirection.None)]
    [Description("Gets or sets the default sort direction of a column.")]
    [Parameter]
    public SortDirection SortDirection { get; set; } = SortDirection.None;

    internal string SortIconName => GetSortIconName();

    /// <summary>
    /// Expression used for sorting.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Expression used for sorting.")]
    [ParameterTypeName("Expression<Func<TItem, IComparable>>")]
    [Parameter]
    public Expression<Func<TItem, IComparable>> SortKeySelector { get; set; } = default!;

    /// <summary>
    /// Gets or sets the column sort string.
    /// This value will be passed to the backend/API for sorting.
    /// And this property is ignored for the client-side sorting.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the column sort string. This value will be passed to the backend/API for sorting. And this property is ignored for the client-side sorting.")]
    [Parameter]
    public string SortString { get; set; } = default!;

    /// <summary>
    /// Gets or sets the StringComparison.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="StringComparison.OrdinalIgnoreCase" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(StringComparison.OrdinalIgnoreCase)]
    [Description("Gets or sets the StringComparison.")]
    [Parameter]
    public StringComparison StringComparison { get; set; } = StringComparison.OrdinalIgnoreCase;

    internal string? ThClassNames => ThCssClass;

    /// <summary>
    /// Gets or sets the CSS class for the table header.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS class for the table header.")]
    [Parameter] public string? ThCssClass { get; set; }

    /// <summary>
    /// Gets or sets the CSS style for the table header.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS style for the table header.")]
    [Parameter] public string? ThCssStyle { get; set; }

    internal string? ThStyleNames => ThCssStyle;

    #endregion
}
