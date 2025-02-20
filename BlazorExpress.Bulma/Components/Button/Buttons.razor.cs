namespace BlazorExpress.Bulma;

public partial class Buttons : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Buttons, true),
            (Size.ToButtonsSizeClass(), Size != ButtonSize.None)
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
    /// <remarks>
    /// Default value is <see cref="ButtonSize.None" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(ButtonSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter] public ButtonSize Size { get; set; } = ButtonSize.None;

    #endregion
}
