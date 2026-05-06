namespace BlazorExpress.Bulma;

/// <summary>
/// PanelBlock component
/// <para>
///     <see href="https://bulma.io/documentation/components/panel/" />
/// </para>
/// </summary>
public partial class PanelBlock : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.PanelBlock, true),
            (BulmaCssClass.IsActive, IsActive)
        );

    private bool RenderAsLabel => !RenderAsLink && IsLabel;

    private bool RenderAsLink => !string.IsNullOrWhiteSpace(Href);

    /// <summary>
    /// Gets or sets the child content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the hyperlink reference. If set, the panel block renders an anchor element.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the hyperlink reference. If set, the panel block renders an anchor element.")]
    [Parameter]
    public string? Href { get; set; }

    /// <summary>
    /// Gets or sets the active state.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the active state.")]
    [Parameter]
    public bool IsActive { get; set; } = false;

    /// <summary>
    /// If <see langword="true" />, the panel block renders a label element when <see cref="Href" /> is not set.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the panel block renders a label element when <code>Href</code> is not set.")]
    [Parameter]
    public bool IsLabel { get; set; } = false;

    #endregion
}
