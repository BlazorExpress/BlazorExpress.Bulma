namespace BlazorExpress.Bulma.Demo.RCL;

public partial class Section : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(
            Class, 
            (BulmaCssClass.Section, true),
            (BulmaCssClass.IsMobile, IsMobile));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public bool IsMobile { get; set; } = true;

    #endregion
}
