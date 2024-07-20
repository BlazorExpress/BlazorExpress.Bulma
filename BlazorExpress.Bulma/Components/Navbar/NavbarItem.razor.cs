namespace BlazorExpress.Bulma;

public partial class NavbarItem : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(
            Class,
            (BulmaCssClass.NavbarItem, true),
            (BulmaCssClass.HasDropdown, HasDropdown),
            (BulmaCssClass.IsHoverable, IsHoverable));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the dropdown state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool HasDropdown { get; set; }

    /// <summary>
    /// Gets or sets the href attribute to the link.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public string? Href { get; set; }

    /// <summary>
    /// Gets or sets the dropdown item hoverable state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="true" />.
    /// </remarks>
    [Parameter]
    public bool IsHoverable { get; set; } = true;

    /// <summary>
    /// Gets or sets the navbar item type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="NavbarItemType.Link" />.
    /// </remarks>
    [Parameter]
    public NavbarItemType Type { get; set; } = NavbarItemType.Link;

    #endregion
}
