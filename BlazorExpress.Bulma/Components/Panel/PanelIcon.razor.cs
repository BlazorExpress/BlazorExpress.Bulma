namespace BlazorExpress.Bulma;

/// <summary>
/// PanelIcon component
/// <para>
///     <see href="https://bulma.io/documentation/components/panel/" />
/// </para>
/// </summary>
public partial class PanelIcon : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames => BuildClassNames(Class, (BulmaCssClass.PanelIcon, true));

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

    #endregion
}
