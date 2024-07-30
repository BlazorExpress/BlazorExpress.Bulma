namespace BlazorExpress.Bulma;

public partial class PaginationLink : BulmaComponentBase
{

    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(
            Class,
            (Type.ToPaginationLinkTypeClass(), true),
            (BulmaCssClass.IsCurrent, IsCurrentPage),
            (BulmaCssClass.IsDisabled, IsDisabled));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool IsCurrentPage { get; set; }

    [Parameter]
    public bool IsDisabled { get; set; }

    /// <summary>
    /// Gets or sets the  <see cref="PaginationLink"/> type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="PaginationLinkType.None" />.
    /// </remarks>
    [Parameter]
    public PaginationLinkType Type { get; set; } = PaginationLinkType.None;

    #endregion
}
