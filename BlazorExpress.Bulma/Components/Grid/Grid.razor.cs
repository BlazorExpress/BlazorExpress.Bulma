namespace BlazorExpress.Bulma;

public partial class Grid<TItem> : BulmaComponentBase
{
    #region Fields and Constants

    private CancellationTokenSource cancellationTokenSource = default!;

    private List<GridColumn<TItem>> columns = new();

    private bool isLoading;

    #endregion

    #region Methods

    protected override void OnAfterRender(bool firstRender)
    {
        isLoading = false;
        base.OnAfterRender(firstRender);
    }

    protected override void OnInitialized()
    {
        isLoading = true;
        base.OnInitialized();
    }

    protected override Task OnParametersSetAsync()
    {
        if (Data is not null && DataProvider is not null)
            throw new InvalidOperationException($"{nameof(Grid<TItem>)} requires one of {nameof(Data)} or {nameof(DataProvider)}, but both were specified.");

        if (AllowPaging && PageSize < 0)
            throw new ArgumentException($"{nameof(PageSize)} must be greater than zero.");

        return base.OnParametersSetAsync();
    }

    internal void AddColumn(GridColumn<TItem> column)
    {
        columns.Add(column);
        StateHasChanged(); // TODO: check this is required or not?
    }

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames =>
        CssUtility.BuildClassNames(
            Class,
            (BulmaCssClass.Table, true),
            (BulmaCssClass.IsBordered, IsBordered),
            (BulmaCssClass.IsStriped, IsStriped),
            (BulmaCssClass.IsNarrow, IsNarrow),
            (BulmaCssClass.IsHoverable, IsHoverable),
            (BulmaCssClass.IsFullWidth, IsFullWidth)
        );

    protected override string? CssStyleNames =>
        CssUtility.BuildStyleNames(
            Style,
            ($"{BulmaCssVariable.SkeletonBlockMinHeight}:{SkeletonBlockMinHeight.ToString(CultureInfo.InvariantCulture)}{Unit.ToUnitCssString()};", true)
        );

    /// <summary>
    /// Gets or sets the grid filtering.
    /// </summary>
    /// <remarks>
    /// Default value is false.
    /// </remarks>
    [Parameter]
    public bool AllowFiltering { get; set; }

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
    /// DataProvider is for items to render.
    /// The provider should always return an instance of 'GridDataProviderResult', and 'null' is not allowed.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public GridDataProvider<TItem> DataProvider { get; set; } = default!;

    /// <summary>
    /// Gets or sets the empty data template.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public RenderFragment? EmptyDataTemplate { get; set; }

    /// <summary>
    /// Gets or sets the empty data text.
    /// </summary>
    /// <remarks>
    /// Default value is 'No records to display'.
    /// </remarks>
    [Parameter]
    public string EmptyDataText { get; set; } = "No records to display";

    private string? GridContainerClassNames =>
        CssUtility.BuildClassNames(
            GridContainerCssClass,
            (BulmaCssClass.TableContianer, IsResponsive)
        );

    /// <summary>
    /// Gets or sets the grid container css class.
    /// </summary>
    [Parameter]
    public string? GridContainerCssClass { get; set; }

    /// <summary>
    /// Gets or sets the grid container css style.
    /// </summary>
    [Parameter]
    public string? GridContainerCssStyle { get; set; }

    private string? GridContainerStyleNames => GridContainerCssStyle;

    private string? GridTbodyClassNames => GridTheadCssClass;

    /// <summary>
    /// Gets or sets the tbody element css class.
    /// </summary>
    [Parameter]
    public string? GridTbodyCssClass { get; set; }

    /// <summary>
    /// Gets or sets the tbody element css style.
    /// </summary>
    [Parameter]
    public string? GridTbodyCssStyle { get; set; }

    private string? GridTbodyStyleNames => GridTheadCssStyle;

    private string? GridTheadClassNames => GridTheadCssClass;

    /// <summary>
    /// Gets or sets the thead element css class.
    /// </summary>
    [Parameter]
    public string? GridTheadCssClass { get; set; }

    /// <summary>
    /// Gets or sets the thead element css style.
    /// </summary>
    [Parameter]
    public string? GridTheadCssStyle { get; set; }

    private string? GridTheadRowClassNames => GridTheadCssClass;

    /// <summary>
    /// Gets or sets the thead's tr element css class.
    /// </summary>
    [Parameter]
    public string? GridTheadRowCssClass { get; set; }

    /// <summary>
    /// Gets or sets the thead's tr element css style.
    /// </summary>
    [Parameter]
    public string? GridTheadRowCssStyle { get; set; }

    private string? GridTheadRowStyleNames => GridTheadRowCssStyle;

    private string? GridTheadStyleNames => GridTheadCssStyle;

    /// <summary>
    /// Gets or sets the grid height.
    /// </summary>
    /// <remarks>
    /// Default value is 320 <see cref="Unit.Px" />.
    /// </remarks>
    [Parameter]
    public float Height { get; set; } = 320;

    /// <summary>
    /// Indicates whether to add borders to all cells.
    /// </summary>
    /// <remarks>
    /// Defaults to `false`.
    /// </remarks>
    [Parameter]
    public bool IsBordered { get; set; }

    [Parameter] public bool IsFullWidth { get; set; } = true;

    /// <summary>
    /// Indicates whether to add a hover effect to each row.
    /// </summary>
    /// <remarks>
    /// Defaults to `false`.
    /// </remarks>
    [Parameter]
    public bool IsHoverable { get; set; }

    /// <summary>
    /// Indicates whether to make the cells narrower.
    /// </summary>
    /// <remarks>
    /// Defaults to `false`.
    /// </remarks>
    [Parameter]
    public bool IsNarrow { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the grid is responsive.
    /// </summary>
    /// <remarks>
    /// Default value is false.
    /// </remarks>
    [Parameter]
    public bool IsResponsive { get; set; }

    /// <summary>
    /// Indicates whether to add stripes to the table.
    /// </summary>
    /// <remarks>
    /// Defaults to `false`.
    /// </remarks>
    [Parameter]
    public bool IsStriped { get; set; }

    /// <summary>
    /// Gets or sets the items per page text.
    /// </summary>
    /// <remarks>
    /// Default value is 'Items per page'.
    /// </remarks>
    [Parameter]
    public string ItemsPerPageText { get; set; } = "Items per page"!;

    /// <summary>
    /// Gets or sets the loading template.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public RenderFragment? LoadingTemplate { get; set; }

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
    public string PaginationItemsTextFormat { get; set; } = "{0} - {1} of {2} items"!;

    [Parameter] public float SkeletonBlockMinHeight { get; set; } = 20;

    /// <summary>
    /// Gets or sets the units of measurement.
    /// </summary>
    /// <remarks>
    /// Defaults to <see cref="Unit.Px" />.
    /// </remarks>
    [Parameter]
    public Unit Unit { get; set; } = Unit.Px;

    #endregion
}
