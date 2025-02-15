namespace BlazorExpress.Bulma;

public partial class Grid<TItem> : BulmaComponentBase
{
    #region Fields and Constants

    private CancellationTokenSource cancellationTokenSource = default!;

    private List<GridColumn<TItem>> columns = new();

    private GridDetailView<TItem>? detailView;

    public GridEmptyDataTemplate<TItem>? emptyDataTemplate;

    public GridLoadingTemplate<TItem>? loadingTemplate;

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

    internal void SetGridDetailView(GridDetailView<TItem> detailView) => this.detailView = detailView;

    internal void SetGridEmptyDataTemplate(GridEmptyDataTemplate<TItem> emptyDataTemplate) => this.emptyDataTemplate = emptyDataTemplate;

    internal void SetGridLoadingTemplate(GridLoadingTemplate<TItem> loadingTemplate) => this.loadingTemplate = loadingTemplate;

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
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the grid filtering.")]
    [Parameter]
    public bool AllowFiltering { get; set; }

    /// <summary>
    /// Gets or sets the grid paging.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the grid paging.")]
    [Parameter]
    public bool AllowPaging { get; set; }

    /// <summary>
    /// Gets or sets the grid sorting.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the grid sorting.")]
    [Parameter]
    public bool AllowSorting { get; set; }

    /// <summary>
    /// Automatically hides the paging controls when the grid item count is less than or equal to the <see cref="PageSize" />
    /// and this property is set to <see langword="true"/>.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Automatically hides the paging controls when the grid item count is less than or equal to the <code>PageSize</code> and this property is set to <b>true</b>.")]
    [Parameter]
    public bool AutoHidePaging { get; set; }

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the grid data.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the grid data.")]
    [Parameter]
    public IEnumerable<TItem> Data { get; set; } = default!;

    /// <summary>
    /// DataProvider is for items to render.
    /// The provider should always return an instance of 'GridDataProviderResult', and 'null' is not allowed.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description($"DataProvider is for items to render. The provider should always return an instance of <code>GridDataProviderResult</code>, and <b>null</b> is not allowed.")]
    [Parameter]
    public GridDataProvider<TItem> DataProvider { get; set; } = default!;

    /// <summary>
    /// Gets or sets the empty data text.
    /// </summary>
    /// <remarks>
    /// Default value is 'No records to display'.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue("No records to display")]
    [Description("Gets or sets the empty data text.")]
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
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the grid container css class.")]
    [Parameter]
    public string? GridContainerCssClass { get; set; }

    /// <summary>
    /// Gets or sets the grid container css style.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the grid container css style.")]
    [Parameter]
    public string? GridContainerCssStyle { get; set; }

    private string? GridContainerStyleNames => GridContainerCssStyle;

    /// <summary>
    /// Gets or sets the grid detail view.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the grid detail view.")]
    [Parameter]
    public RenderFragment? GridDetailView { get; set; }

    private string? GridTbodyClassNames => GridTheadCssClass;

    /// <summary>
    /// Gets or sets the tbody element css class.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the <code>tbody</code> element css class.")]
    [Parameter]
    public string? GridTbodyCssClass { get; set; }

    /// <summary>
    /// Gets or sets the tbody element css style.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the <code>tbody</code> element css style.")]
    [Parameter]
    public string? GridTbodyCssStyle { get; set; }

    private string? GridTbodyStyleNames => GridTheadCssStyle;

    private string? GridTheadClassNames => GridTheadCssClass;

    /// <summary>
    /// Gets or sets the thead element css class.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the <code>thead</code> element css class.")]
    [Parameter]
    public string? GridTheadCssClass { get; set; }

    /// <summary>
    /// Gets or sets the thead element css style.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the <code>thead</code> element css style.")]
    [Parameter]
    public string? GridTheadCssStyle { get; set; }

    private string? GridTheadRowClassNames => GridTheadCssClass;

    /// <summary>
    /// Gets or sets the thead's tr element css class.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the thead's <code>tr</code> element css class.")]
    [Parameter]
    public string? GridTheadRowCssClass { get; set; }

    /// <summary>
    /// Gets or sets the thead's tr element css style.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the thead's <code>tr</code> element css style.")]
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
    [AddedVersion("1.0.0")]
    [DefaultValue(320)]
    [Description("Gets or sets the grid height. Height will be in pixels.")]
    [Parameter]
    public float Height { get; set; } = 320;

    /// <summary>
    /// Indicates whether to add borders to all cells.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Indicates whether to add borders to all cells.")]
    [Parameter]
    public bool IsBordered { get; set; }

    /// <summary>
    /// Indicates whether to make the table full width.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="true"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(true)]
    [Description("Indicates whether to make the table full width.")]
    [Parameter] public bool IsFullWidth { get; set; } = true;

    /// <summary>
    /// Indicates whether to add a hover effect to each row.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Indicates whether to add a hover effect to each row.")]
    [Parameter]
    public bool IsHoverable { get; set; }

    /// <summary>
    /// Indicates whether to make the cells narrower.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Indicates whether to make the cells narrower.")]
    [Parameter]
    public bool IsNarrow { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the grid is responsive.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets a value indicating whether the grid is responsive.")]
    [Parameter]
    public bool IsResponsive { get; set; }

    /// <summary>
    /// Indicates whether to add stripes to the table.
    /// </summary>
    /// <remarks>
    /// Defaults to <see langword="false"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Indicates whether to add stripes to the table.")]
    [Parameter]
    public bool IsStriped { get; set; }

    /// <summary>
    /// Gets or sets the items per page text.
    /// </summary>
    /// <remarks>
    /// Default value is 'Items per page'.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue("Items per page")]
    [Description("Gets or sets the items per page text.")]
    [Parameter]
    public string ItemsPerPageText { get; set; } = "Items per page"!;

    /// <summary>
    /// Gets or sets the page size.
    /// </summary>
    /// <remarks>
    /// Default value is 10.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(10)]
    [Description("Gets or sets the page size.")]
    [Parameter]
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// Gets or sets the page size selector items.
    /// </summary>
    /// <remarks>
    /// Default value is '{ 10, 20, 50 }'.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue("{ 10, 20, 50 }")]
    [Description("Gets or sets the page size selector items.")]
    [Parameter]
    public int[] PageSizeSelectorItems { get; set; } = { 10, 20, 50 };

    /// <summary>
    /// Gets or sets the page size selector visible.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="true" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(true)]
    [Description("Gets or sets the page size selector visible.")]
    [Parameter]
    public bool PageSizeSelectorVisible { get; set; } = true;

    /// <summary>
    /// Event fired when the page size value changes.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Event fired when the page size value changes.")]
    [Parameter] public EventCallback<int> PageSizeValueChanged { get; set; }

    private string PaginationItemsText => GetPaginationItemsText();

    /// <summary>
    /// Gets or sets the pagination items text format.
    /// </summary>
    /// <remarks>
    /// Default value is '{0} - {1} of {2} items'.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue("{0} - {1} of {2} items")]
    [Description("Gets or sets the pagination items text format.")]
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
    [AddedVersion("1.0.0")]
    [DefaultValue(24)]
    [Description("Gets or sets the minimum height of the skeleton block. Skeletons are displayed while a request is in progress.")]
    [Parameter]
    public float SkeletonBlockMinHeight { get; set; } = 24;

    private int TotalPages => GetTotalPagesCount();

    /// <summary>
    /// Gets or sets the units of measurement.
    /// </summary>
    /// <remarks>
    /// Defaults to <see cref="Unit.Px" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(Unit.Px)]
    [Description("Gets or sets the units of measurement.")]
    [Parameter]
    public Unit Unit { get; set; } = Unit.Px;

    #endregion
}
