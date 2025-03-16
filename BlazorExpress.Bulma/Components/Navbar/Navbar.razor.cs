namespace BlazorExpress.Bulma;

/// <summary>
/// Navbar component
/// <para>
/// <see href="https://bulma.io/documentation/components/navbar/" />
/// </para>
/// </summary>
public partial class Navbar : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Navbar, true),
            (BulmaCssClass.IsSpaced, IsSpaced),
            (BulmaCssClass.HasShadow, HasShadow)
        );

    protected override string? StyleNames => 
        BuildStyleNames(
            Style//, 
            //("height:var(--be-bulma-navbar-height);", true)
        );

    /// <summary>
    /// Gets or sets the child content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// If <see langword="true" />, adds a small amount of box-shadow around the navbar.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, adds a small amount of box-shadow around the navbar.")]
    [Parameter]
    public bool HasShadow { get; set; } = false;

    /// <summary>
    /// If <see langword="true" />, sets Top and Bottom paddings with 1rem, Left and Right paddings with 2rem.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, sets Top and Bottom paddings with 1rem, Left and Right paddings with 2rem.")]
    [Parameter]
    public bool IsSpaced { get; set; } = false;

    #endregion
}
