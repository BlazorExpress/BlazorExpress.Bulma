namespace BlazorExpress.Bulma;

/// <summary>
/// NavbarDropdown component
/// <para>
/// <see href="https://bulma.io/documentation/components/navbar/" />
/// </para>
/// </summary>
public partial class NavbarDropdown : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.NavbarDropdown, true),
            (Position.ToNavbarDropdownPositionClass(), true),
            ("px-1", true)
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
    /// Gets or sets the navbar dropdown position.
    /// <para>
    /// Default value is <see cref="NavbarDropdownPosition.Left" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(NavbarDropdownPosition.Left)]
    [Description("Gets or sets the navbar dropdown position.")]
    [Parameter]
    public NavbarDropdownPosition Position { get; set; } = NavbarDropdownPosition.Left;

    #endregion
}
