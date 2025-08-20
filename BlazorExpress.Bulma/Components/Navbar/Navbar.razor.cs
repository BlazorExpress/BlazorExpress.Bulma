namespace BlazorExpress.Bulma;

/// <summary>
/// Navbar component
/// <para>
///     <see href="https://bulma.io/documentation/components/navbar/" />
/// </para>
/// </summary>
public partial class Navbar : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Navbar, true),
            (Color.ToNavbarColorClass(), Color != NavbarColor.None),
            (BulmaCssClass.HasShadow, HasShadow),
            (BulmaCssClass.IsSpaced, IsSpaced),
            (BulmaCssClass.IsTransparent, IsTransparent)
        );

    protected override string? StyleNames =>
        BuildStyleNames(
            Style //, 
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
    /// Gets or sets the color.
    /// <para>
    /// Default value is <see cref="NavbarColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(NavbarColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter]
    public NavbarColor Color { get; set; } = NavbarColor.None;

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

    /// <summary>
    /// If <see langword="true" />, this will remove any hover or active background color from the navbar.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, this will remove any hover or active background color from the navbar.")]
    [Parameter]
    public bool IsTransparent { get; set; } = false;

    #endregion
}
