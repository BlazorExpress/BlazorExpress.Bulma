namespace BlazorExpress.Bulma;

/// <summary>
/// Pagination component
/// <see href="https://bulma.io/documentation/components/pagination/" />
/// </summary>
public partial class Pagination : BulmaComponentBase
{
    #region Methods

    protected override void OnInitialized()
    {
        if (AdditionalAttributes is null)
            AdditionalAttributes = new Dictionary<string, object>();

        AdditionalAttributes.Add("role", "navigation");
        AdditionalAttributes.Add("aria-label", BulmaCssClass.Pagination);

        base.OnInitialized();
    }

    private int GetPageFromInclusive()
    {
        var q = ActivePageNumber / DisplayPages;
        var r = ActivePageNumber % DisplayPages;

        if (q < 1)
            return 1;

        if (q > 0 && r == 0)
            return (q - 1) * DisplayPages + 1;

        if (q > 1 && r < DisplayPages)
            return q * DisplayPages + 1;

        return ActivePageNumber / DisplayPages * DisplayPages + 1;
    }

    private int GetPageToExclusive() => TotalPages == 0 ? 1 : Math.Min(TotalPages, PageFromInclusive + DisplayPages - 1);

    private void GoToNextPage()
    {
        if (ActivePageNumber == TotalPages || TotalPages == 0 || TotalPages == 1)
            return;

        ActivePageNumber += 1;

        if (PageChanged.HasDelegate)
            PageChanged.InvokeAsync(ActivePageNumber);
    }

    private void GoToPage(int pageNumber)
    {
        if (pageNumber < 1 || pageNumber > TotalPages)
            return;

        ActivePageNumber = pageNumber;

        if (PageChanged.HasDelegate)
            PageChanged.InvokeAsync(ActivePageNumber);
    }

    private void GoToPreviousPage()
    {
        if (ActivePageNumber <= 1)
            return;

        ActivePageNumber -= 1;

        if (PageChanged.HasDelegate)
            PageChanged.InvokeAsync(ActivePageNumber);
    }

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames =>
        CssUtility.BuildClassNames(
            Class,
            (BulmaCssClass.Pagination, true),
            (Alignment.ToPaginationAlignmentClass(), Alignment != PaginationAlignment.None),
            (BulmaCssClass.IsRounded, IsRounded),
            (Size.ToPaginationSizeClass(), Size != PaginationSize.None)
        );

    /// <summary>
    /// Gets or sets the active page number.
    /// </summary>
    /// <remarks>
    /// Default value is 1.
    /// </remarks>
    [Parameter]
    public int ActivePageNumber { get; set; } = 1;

    /// <summary>
    /// Get or sets the <see cref="Pagination" /> alignment.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="PaginationAlignment.None" />.
    /// </remarks>
    [Parameter]
    public PaginationAlignment Alignment { get; set; }

    /// <summary>
    /// Gets or sets the maximum page links to be displayed.
    /// </summary>
    /// <remarks>
    /// Default value is 5.
    /// </remarks>
    [Parameter]
    public int DisplayPages { get; set; } = 5;

    /// <summary>
    /// When set to <see langword="true" />, changes the appearance of <see cref="PaginationItem" /> to rounded.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool IsRounded { get; set; }

    [Parameter] public RenderFragment? NextButtonTemplate { get; set; }

    /// <summary>
    /// This event fires immediately when the page number is changed.
    /// </summary>
    [Parameter]
    public EventCallback<int> PageChanged { get; set; }

    private int PageFromInclusive => GetPageFromInclusive();

    private int PageToExclusive => GetPageToExclusive();

    [Parameter] public RenderFragment? PreviousButtonTemplate { get; set; }

    /// <summary>
    /// Get or sets the <see cref="Pagination" /> size.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="PaginationSize.None" />.
    /// </remarks>
    [Parameter]
    public PaginationSize Size { get; set; }

    /// <summary>
    /// Gets or sets the total pages.
    /// </summary>
    /// <remarks>
    /// Default value is 0.
    /// </remarks>
    [Parameter]
    public int TotalPages { get; set; }

    #endregion
}
