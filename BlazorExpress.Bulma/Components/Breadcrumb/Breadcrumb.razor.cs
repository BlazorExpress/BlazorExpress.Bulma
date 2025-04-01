namespace BlazorExpress.Bulma;

/// <summary>
/// Breadcrumb component
/// <para>
/// <see href="https://bulma.io/documentation/components/breadcrumb/" />
/// </para>
/// </summary>
public partial class Breadcrumb : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames => 
        BuildClassNames(
            Class, 
            (BulmaCssClass.Breadcrumb, true),
            (Alignment.ToBreadcrumbAlignmentClass(), Alignment != BreadcrumbAlignment.None),
            (Size.ToBreadcrumbSizeClass(), Size != BreadcrumbSize.None)
        );

    /// <summary>
    /// Gets or sets the breadcrumb alignment.
    /// <para>
    /// Default value is <see cref="BreadcrumbAlignment.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(BreadcrumbAlignment.None)]
    [Description("Gets or sets the breadcrumb alignment.")]
    [Parameter]
    public BreadcrumbAlignment Alignment { get; set; } = BreadcrumbAlignment.None;

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
    /// Gets or sets the size.
    /// <para>
    /// Default value is <see cref="TextInputSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(BreadcrumbSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter]
    public BreadcrumbSize Size { get; set; } = BreadcrumbSize.None;

    #endregion
}
