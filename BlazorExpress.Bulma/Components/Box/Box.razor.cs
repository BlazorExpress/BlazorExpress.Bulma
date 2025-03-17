namespace BlazorExpress.Bulma;

/// <summary>
/// Box component
/// <para>
///     <see href="https://bulma.io/documentation/elements/box/" />
/// </para>
/// </summary>
public partial class Box : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames => BuildClassNames(Class, (BulmaCssClass.Box, true));

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

    #endregion
}
