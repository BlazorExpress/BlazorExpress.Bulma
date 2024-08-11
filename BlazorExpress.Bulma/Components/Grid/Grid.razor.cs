namespace BlazorExpress.Bulma;

public partial class Grid<TItem> : BulmaComponentBase
{
    #region Fields and Constants

    private CancellationTokenSource cancellationTokenSource = default!;

    private List<GridColumn<TItem>> columns = new();

    /// <summary>
    /// Current grid state (filters, paging, sorting).
    /// </summary>
    internal GridState<TItem> gridCurrentState = default!;

    private bool isLoading;

    private IEnumerable<TItem> items = default!;

    private object? lastAssignedDataOrDataProvider;

    private int totalCount;

    #endregion

    #region Methods

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        Console.WriteLine("Grid.OnAfterRender() called");

        if (firstRender)
        {
            Console.WriteLine("Grid.OnAfterRender() called - firstRender");
            await RefreshGridCoreAsync();
            HideLoading();
            StateHasChanged();
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    protected override void OnInitialized()
    {
        Console.WriteLine("Grid.OnInitialized() called");

        gridCurrentState = new GridState<TItem>(1, PageSize, null);
        ShowLoading();
        base.OnInitialized();
    }

    protected override async Task OnParametersSetAsync()
    {
        Console.WriteLine("Grid.OnParametersSetAsync() called");

        if (Data is not null && DataProvider is not null)
            throw new InvalidOperationException($"{nameof(Grid<TItem>)} requires one of {nameof(Data)} or {nameof(DataProvider)}, but both were specified.");

        if (AllowPaging && PageSize < 0)
            throw new ArgumentException($"{nameof(PageSize)} must be greater than zero.");

        if (IsRenderComplete)
        {
            // Perform a re-query only if the data source or something else has changed
            var newDataOrDataProvider = Data ?? (object?)DataProvider;

            var dataSourceHasChanged = newDataOrDataProvider != lastAssignedDataOrDataProvider;

            // dataSourceHasChanged might be true even after rendering.
            // This can happen because data might be null when the first RefreshGridCoreAsync method is called.
            // The data is then assigned.
            // If the data source has changed, update the last assigned data or data provider.
            if (dataSourceHasChanged)
                lastAssignedDataOrDataProvider = newDataOrDataProvider;

            var pageSizeChanged = gridCurrentState.PageSize != PageSize;

            if (pageSizeChanged)
                gridCurrentState = new GridState<TItem>(gridCurrentState.PageNumber, PageSize, gridCurrentState.Sorting);

            var mustRefreshData = dataSourceHasChanged || pageSizeChanged;

            if (mustRefreshData) await RefreshGridAsync();
        }

        await base.OnParametersSetAsync();
    }

    internal void AddColumn(GridColumn<TItem> column)
    {
        columns.Add(column);
        StateHasChanged(); // TODO: check this is required or not?
    }

    internal void HideLoading() => isLoading = false;

    internal void ShowLoading() => isLoading = true;

    private IEnumerable<SortingItem<TItem>>? GetDefaultSorting() =>
        !AllowSorting || columns == null || !columns.Any()
            ? null
            : columns?.Where(column => column.CanSort() && column.IsDefaultSortColumn)?.SelectMany(item => item.GetSorting());

    private string GetPaginationItemsText()
    {
        var fromItemNumber = (gridCurrentState.PageNumber - 1) * gridCurrentState.PageSize + 1;
        var toItemNumber = gridCurrentState.PageNumber * gridCurrentState.PageSize;

        if (toItemNumber > totalCount)
            toItemNumber = totalCount;

        return string.Format(PaginationItemsTextFormat, fromItemNumber, toItemNumber, totalCount);
    }

    private int GetTotalPagesCount()
    {
        if (totalCount > 0)
        {
            var q = totalCount / gridCurrentState.PageSize;
            var r = totalCount % gridCurrentState.PageSize;

            return q < 1 ? 1 : q + (r > 0 ? 1 : 0);
        }

        return 1;
    }

    private async Task OnPageChangedAsync(int newPageNumber)
    {
        ShowLoading();
        gridCurrentState = new GridState<TItem>(newPageNumber, gridCurrentState.PageSize, gridCurrentState.Sorting);
        await RefreshGridCoreAsync();
        HideLoading();
        StateHasChanged();
    }

    private async Task OnPageSizeChangedAsync(int newPageSize)
    {
        ShowLoading();
        gridCurrentState = new GridState<TItem>(1, newPageSize, gridCurrentState.Sorting); // reset page number
        await RefreshGridCoreAsync();
        HideLoading();
        StateHasChanged();

        if (PageSizeValueChanged.HasDelegate)
            await PageSizeValueChanged.InvokeAsync(newPageSize);
    }

    private async Task OnSortClickAsync(MouseEventArgs e, GridColumn<TItem> column)
    {
        Console.WriteLine("Grid.OnSortClickAsync() called");
        Console.WriteLine($"Column Id={column.Id}");

        if (!AllowSorting || !(columns?.Any() ?? false)) return;

        ShowLoading();

        // update sorting
        columns.ForEach(
            c =>
            {
                if (c.Id == column.Id)
                {
                    switch (c.currentSortDirection)
                    {
                        case SortDirection.None:
                            c.currentSortDirection = SortDirection.Ascending;

                            break;
                        case SortDirection.Ascending:
                            c.currentSortDirection = SortDirection.Descending;

                            break;
                        case SortDirection.Descending:
                            c.currentSortDirection = SortDirection.None;

                            break;
                        default:
                            c.currentSortDirection = SortDirection.Ascending;

                            break;
                    }

                    gridCurrentState = new GridState<TItem>(gridCurrentState.PageNumber, gridCurrentState.PageSize, c.GetSorting());
                }
                else
                {
                    c.currentSortDirection = SortDirection.None;
                }
            }
        );

        await RefreshGridCoreAsync();
        HideLoading();
        StateHasChanged();
    }

    private async Task RefreshGridAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Grid.RefreshGridAsync() called");
        await RefreshGridCoreAsync(cancellationToken);
        StateHasChanged();
    }

    private async Task RefreshGridCoreAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Grid.RefreshGridCoreAsync() called");
        var request = new GridDataProviderRequest<TItem> { PageNumber = AllowPaging ? gridCurrentState.PageNumber : default!, PageSize = AllowPaging ? gridCurrentState.PageSize : default!, Sorting = AllowSorting ? gridCurrentState.Sorting ?? GetDefaultSorting()! : null!, CancellationToken = cancellationToken };

        GridDataProviderResult<TItem> result = default!;

        if (DataProvider is not null)
            result = await DataProvider.Invoke(request);
        else if (Data is not null)
            result = request.ApplyTo(Data);

        if (result is not null)
        {
            items = result.Data;
            totalCount = result.TotalCount;
        }
        else
        {
            items = null!;
            totalCount = 0;
        }
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
    public int[] PageSizeSelectorItems { get; set; } = { 10, 20, 50 };

    /// <summary>
    /// Gets or sets the page size selector visible.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="true" />.
    /// </remarks>
    [Parameter]
    public bool PageSizeSelectorVisible { get; set; } = true;

    [Parameter] public EventCallback<int> PageSizeValueChanged { get; set; }

    private string PaginationItemsText => GetPaginationItemsText();

    /// <summary>
    /// Gets or sets the pagination items text format.
    /// </summary>
    /// <remarks>
    /// Default value is '{0} - {1} of {2} items'.
    /// </remarks>
    [Parameter]
    public string PaginationItemsTextFormat { get; set; } = "{0} - {1} of {2} items"!;

    /// <summary>
    /// Gets or sets the minimum height of the skeleton block.
    /// Skeletons are displayed while a request is in progress.
    /// </summary>
    /// <remarks>
    /// Default value is 24.
    /// Unit is based on the <see cref="Unit" />.
    /// </remarks>
    [Parameter]
    public float SkeletonBlockMinHeight { get; set; } = 24;

    private int TotalPages => GetTotalPagesCount();

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
