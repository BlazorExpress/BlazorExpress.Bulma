namespace BlazorExpress.Bulma;

/// <summary>
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

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(
            Class, 
            (BulmaCssClass.Pagination, true),
            (Alignment.ToPaginationAlignmentClass(), Alignment != PaginationAlignment.None),
            (BulmaCssClass.IsRounded, IsRounded),
            (Size.ToPaginationSizeClass(), Size != PaginationSize.None));

    /// <summary>
    /// Get or sets the <see cref="Pagination" /> alignment.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="PaginationAlignment.None" />.
    /// </remarks>
    [Parameter]
    public PaginationAlignment Alignment { get; set; }

    /// <summary>
    /// When set to <see langword="true"/>, changes the appearance of <see cref="PaginationItem"/> to rounded.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false"/>.
    /// </remarks>
    [Parameter]
    public bool IsRounded { get; set; }

    /// <summary>
    /// Get or sets the <see cref="Pagination" /> size.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="PaginationSize.None" />.
    /// </remarks>
    [Parameter]
    public PaginationSize Size { get; set; }

    #endregion
}
