namespace BlazorExpress.Bulma;

/// <summary>
/// <see href="https://bulma.io/documentation/components/navbar/" />
/// </summary>
public partial class Navbar : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames => CssUtility.BuildClassNames(
            Class, 
            (BulmaCssClass.Navbar, true),
            (BulmaCssClass.IsSpaced, IsSpaced),
            (BulmaCssClass.HasShadow, HasShadow));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// If <see langword="true"/>, adds a small amount of box-shadow around the navbar.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [Parameter]
    public bool HasShadow { get; set; }

    /// <summary>
    /// If <see langword="true"/>, sets Top and Bottom paddings with 1rem, Left and Right paddings with 2rem.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [Parameter]
    public bool IsSpaced { get; set; }

    #endregion
}
