namespace BlazorExpress.Bulma;

/// <summary>
/// CardHeaderIcon component
/// <para>
///     <see href="https://bulma.io/documentation/components/card/" />
/// </para>
/// </summary>
public partial class CardHeaderIcon : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames => BuildClassNames(Class, (BulmaCssClass.CardHeaderIcon, true));

    /// <summary>
    /// Gets or sets the accessible label for the header icon button.
    /// <para>
    /// Default value is <c>more options</c>.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue("more options")]
    [Description("Gets or sets the accessible label for the header icon button.")]
    [Parameter]
    public string AriaLabel { get; set; } = "more options";

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
