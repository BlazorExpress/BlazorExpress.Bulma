namespace BlazorExpress.Bulma;

/// <summary>
/// <see href="https://bulma.io/documentation/components/tabs/" />
/// </summary>
public partial class Tab : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(Class, (BulmaCssClass.Block, true));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion
}
