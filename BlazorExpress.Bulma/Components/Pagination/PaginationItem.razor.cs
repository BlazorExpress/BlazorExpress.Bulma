namespace BlazorExpress.Bulma;

/// <summary>
/// Pagination component
/// <para>
///     <see href="https://bulma.io/documentation/components/pagination/" />
/// </para>
/// </summary>
public partial class PaginationItem : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (Type.ToPaginationLinkTypeClass(), true),
            (BulmaCssClass.IsCurrent, IsCurrentPage),
            (BulmaCssClass.IsDisabled, IsDisabled)
        );

    /// <summary>
    /// Gets or sets the child content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// If <see langword="true" />, sets the <see cref="PaginationItem" /> as current page.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, sets the <code>PaginationItem</code> as current page.")]
    [Parameter]
    public bool IsCurrentPage { get; set; } = false;

    /// <summary>
    /// If <see langword="true" />, disables the <see cref="PaginationItem" />.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, disables the <code>PaginationItem</code>.")]
    [Parameter]
    public bool IsDisabled { get; set; } = false;

    /// <summary>
    /// Gets or sets the  <see cref="PaginationItem" /> type.
    /// <para>
    /// Default value is <see cref="PaginationLinkType.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(PaginationLinkType.None)]
    [Description("Gets or sets the  <code>PaginationItem</code> type.")]
    [Parameter]
    public
        PaginationLinkType Type { get; set; } = PaginationLinkType.None;

    #endregion
}
