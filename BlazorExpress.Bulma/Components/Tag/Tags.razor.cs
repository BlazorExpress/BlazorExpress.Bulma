namespace BlazorExpress.Bulma;

/// <summary>
/// Tags component
/// <see href="https://bulma.io/documentation/elements/tag/" />
/// </summary>
public partial class Tags : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Tags, true),
            (Size.ToTagsSizeClass(), Size != TagSize.None)
        );

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
    /// Gets or sets the size.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(TagSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter] public TagSize Size { get; set; } = TagSize.None;

    #endregion
}
