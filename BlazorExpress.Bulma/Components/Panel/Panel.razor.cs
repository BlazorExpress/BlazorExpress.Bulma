namespace BlazorExpress.Bulma;

/// <summary>
/// Panel component
/// <para>
///     <see href="https://bulma.io/documentation/components/panel/" />
/// </para>
/// </summary>
public partial class Panel : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Panel, true),
            (Color.ToPanelColorClass(), Color != PanelColor.None)
        );

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
    /// Gets or sets the panel color.
    /// <para>
    /// Default value is <see cref="PanelColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(PanelColor.None)]
    [Description("Gets or sets the panel color.")]
    [Parameter]
    public PanelColor Color { get; set; } = PanelColor.None;

    #endregion
}
