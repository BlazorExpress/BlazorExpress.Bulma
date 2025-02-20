namespace BlazorExpress.Bulma;

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
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the navbar dropdown position.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="NavbarDropdownPosition.Left" />.
    /// </remarks>
    [Parameter]
    public NavbarDropdownPosition Position { get; set; } = NavbarDropdownPosition.Left;

    #endregion
}
