namespace BlazorExpress.Bulma;

public partial class Grid<TItem> : BulmaComponentBase
{
    #region Fields and Constants

    private CancellationTokenSource cancellationTokenSource = default!;

    private List<GridColumn> columns = new();

    private List<TItem>? items = null;

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames => CssUtility.BuildClassNames(Class, (BulmaCssClass.Block, true));

    /// <summary>
    /// Gets or sets the grid paging.
    /// </summary>
    /// <remarks>
    /// Default value is false.
    /// </remarks>
    [Parameter]
    public bool AllowPaging { get; set; }

    /// <summary>
    /// Gets or sets the grid sorting.
    /// </summary>
    /// <remarks>
    /// Default value is false.
    /// </remarks>
    [Parameter]
    public bool AllowSorting { get; set; }

    /// <summary>
    /// Automatically hides the paging controls when the grid item count is less than or equal to the <see cref="PageSize" />
    /// and this property is set to `true`.
    /// </summary>
    /// <remarks>
    /// Default value is false.
    /// </remarks>
    [Parameter]
    public bool AutoHidePaging { get; set; }

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the grid data.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public IEnumerable<TItem> Data { get; set; } = default!;

    /// <summary>
    /// Gets or sets the empty text.
    /// Shows text on no records.
    /// </summary>
    /// <remarks>
    /// Default value is 'No records to display'.
    /// </remarks>
    [Parameter]
    public string EmptyText { get; set; } = "No records to display";

    /// <summary>
    /// Gets or sets the grid container css class.
    /// </summary>
    [Parameter]
    public string? GridContainerClass { get; set; }

    private string? GridContainerClassNames =>
        CssUtility.BuildClassNames(
            GridContainerClass,
            (BulmaCssClass.TableContianer, IsResponsive)
        );

    /// <summary>
    /// Gets or sets the grid container css style.
    /// </summary>
    [Parameter]
    public string? GridContainerStyle { get; set; }

    private string? GridContainerStyleNames => GridContainerStyle;

    /// <summary>
    /// Gets or sets the tbody element css class.
    /// </summary>
    [Parameter]
    public string? GridTbodyClass { get; set; }

    private string? GridTbodyClassNames => GridTheadClass;

    /// <summary>
    /// Gets or sets the tbody element css style.
    /// </summary>
    [Parameter]
    public string? GridTbodyStyle { get; set; }

    private string? GridTbodyStyleNames => GridTheadStyle;

    /// <summary>
    /// Gets or sets the thead element css class.
    /// </summary>
    [Parameter]
    public string? GridTheadClass { get; set; }

    private string? GridTheadClassNames => GridTheadClass;

    /// <summary>
    /// Gets or sets the thead's tr element css class.
    /// </summary>
    [Parameter]
    public string? GridTheadRowClass { get; set; }

    private string? GridTheadRowClassNames => GridTheadClass;

    /// <summary>
    /// Gets or sets the thead's tr element css style.
    /// </summary>
    [Parameter]
    public string? GridTheadRowStyle { get; set; }

    private string? GridTheadRowStyleNames => GridTheadStyle;

    /// <summary>
    /// Gets or sets the thead element css style.
    /// </summary>
    [Parameter]
    public string? GridTheadStyle { get; set; }

    private string? GridTheadStyleNames => GridTheadStyle;

    /// <summary>
    /// Gets or sets the grid height.
    /// </summary>
    /// <remarks>
    /// Default value is 320 <see cref="Unit.Px" />.
    /// </remarks>
    [Parameter]
    public float Height { get; set; } = 320;

    /// <summary>
    /// Gets or sets a value indicating whether the grid is responsive.
    /// </summary>
    /// <remarks>
    /// Default value is false.
    /// </remarks>
    [Parameter]
    public bool IsResponsive { get; set; }

    /// <summary>
    /// Gets or sets the items per page text.
    /// </summary>
    /// <remarks>
    /// Default value is 'Items per page'.
    /// </remarks>
    [Parameter]
    public string ItemsPerPageText { get; set; } = "Items per page"!;

    /// <summary>
    /// Gets or sets the page size.
    /// </summary>
    /// <remarks>
    /// Default value is 10.
    /// </remarks>
    [Parameter]
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// Gets or sets the page size selector items.
    /// </summary>
    /// <remarks>
    /// Default value is '{ 10, 20, 50 }'.
    /// </remarks>
    [Parameter]
    //[EditorRequired]
    public int[] PageSizeSelectorItems { get; set; } = { 10, 20, 50 };

    /// <summary>
    /// Gets or sets the page size selector visible.
    /// </summary>
    /// <remarks>
    /// Default value is false.
    /// </remarks>
    [Parameter]
    public bool PageSizeSelectorVisible { get; set; }

    /// <summary>
    /// Gets or sets the pagination items text format.
    /// </summary>
    /// <remarks>
    /// Default value is '{0} - {1} of {2} items'.
    /// </remarks>
    [Parameter]
    //[EditorRequired]
    public string PaginationItemsTextFormat { get; set; } = "{0} - {1} of {2} items"!;

    /// <summary>
    /// Gets or sets the units.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="Unit.Px" />.
    /// </remarks>
    [Parameter]
    public Unit Unit { get; set; } = Unit.Px;

    #endregion
}
