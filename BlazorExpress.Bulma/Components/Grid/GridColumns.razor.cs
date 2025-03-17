namespace BlazorExpress.Bulma;

public partial class GridColumns : BulmaComponentBase
{
    #region Properties, Indexers

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
    public RenderFragment? ChildContent { get; set; } = default!;

    #endregion
}
