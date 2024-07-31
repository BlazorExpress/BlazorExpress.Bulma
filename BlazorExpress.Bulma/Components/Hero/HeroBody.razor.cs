namespace BlazorExpress.Bulma;

public partial class HeroBody : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames => CssUtility.BuildClassNames(Class, (BulmaCssClass.HeroBody, true));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion
}
