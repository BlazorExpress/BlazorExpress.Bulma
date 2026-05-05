namespace BlazorExpress.Bulma;

/// <summary>
/// Card component
/// <para>
///     <see href="https://bulma.io/documentation/components/card/" />
/// </para>
/// </summary>
public partial class Card : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames => BuildClassNames(Class, (BulmaCssClass.Card, true));

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
