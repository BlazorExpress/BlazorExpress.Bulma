namespace BlazorExpress.Bulma;

public partial class Buttons : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames =>
        CssUtility.BuildClassNames(
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
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter] public ButtonSize Size { get; set; }

    #endregion
}
