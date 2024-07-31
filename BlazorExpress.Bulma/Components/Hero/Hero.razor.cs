namespace BlazorExpress.Bulma;

/// <summary>
/// Hero component
/// <see href="https://bulma.io/documentation/layout/hero/" />
/// </summary>
public partial class Hero : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames => CssUtility.BuildClassNames(Class, (BulmaCssClass.Hero, true));

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
