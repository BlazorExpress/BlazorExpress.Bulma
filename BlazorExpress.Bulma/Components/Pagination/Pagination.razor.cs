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

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Pagination, true),
            (Alignment.ToPaginationAlignmentClass(), Alignment != PaginationAlignment.None),
            (BulmaCssClass.IsRounded, IsRounded),
            (Size.ToPaginationSizeClass(), Size != PaginationSize.None)
        );

    /// <summary>
    /// Gets or sets the active page number.
    /// <para>
    /// Default value is 1.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(1)]
    [Description("Gets or sets the active page number.")]
    public int ActivePageNumber { get; set; } = 1;

    /// <summary>
    /// Get or sets the <see cref="Pagination" /> alignment.
    /// <para>
    /// Default value is <see cref="PaginationAlignment.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(PaginationAlignment.None)]
    [Description("Get or sets the <code>Pagination</code> alignment.")]
    [Parameter]
    public PaginationAlignment Alignment { get; set; } = PaginationAlignment.None;

    /// <summary>
    /// Gets or sets the maximum page links to be displayed.
    /// <para>
    /// Default value is 5.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(5)]
    [Description("Gets or sets the maximum page links to be displayed.")]
    [Parameter]
    public int DisplayPages { get; set; } = 5;

    /// <summary>
    /// When set to <see langword="true" />, changes the appearance of <see cref="PaginationItem" /> to rounded.
    /// <para>
    /// The default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("When set to <b>true</b>, changes the appearance of <code>PaginationItem</code> to rounded.")]
    [Parameter]
    public bool IsRounded { get; set; } = false;

    /// <summary>
    /// Gets or sets the next button template.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the next button template.")]
    [Parameter] 
    public RenderFragment? NextButtonTemplate { get; set; }

    /// <summary>
    /// This event fires immediately when the page number is changed.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires immediately when the page number is changed.")]
    [Parameter]
    public EventCallback<int> PageChanged { get; set; }

    private int PageFromInclusive => GetPageFromInclusive();

    private int PageToExclusive => GetPageToExclusive();

    /// <summary>
    /// Gets or sets the previous button template.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the previous button template.")]
    [Parameter] 
    public RenderFragment? PreviousButtonTemplate { get; set; }

    /// <summary>
    /// Get or sets the <see cref="Pagination" /> size.
    /// </summary>
    /// <para>
    /// Default value is <see cref="PaginationSize.None" />.
    /// </para>
    [AddedVersion("1.0.0")]
    [DefaultValue(PaginationSize.None)]
    [Description("Get or sets the <code>Pagination</code> size.")]
    [Parameter]
    public PaginationSize Size { get; set; } = PaginationSize.None;

    /// <summary>
    /// Gets or sets the total pages.
    /// </summary>
    /// <para>
    /// Default value is 0.
    /// </para>
    [AddedVersion("1.0.0")]
    [DefaultValue(0)]
    [Description("Gets or sets the total pages.")]
    [Parameter]
    public int TotalPages { get; set; } = 0;

    #endregion
}
