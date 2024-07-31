namespace BlazorExpress.Bulma;

/// <summary>
/// Box component
/// <see href="https://bulma.io/documentation/elements/box/" />
/// </summary>
public partial class Box : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames => CssUtility.BuildClassNames(Class, (BulmaCssClass.Box, true));

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
