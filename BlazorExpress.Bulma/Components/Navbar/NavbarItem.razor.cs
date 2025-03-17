namespace BlazorExpress.Bulma;

/// <summary>
/// NavbarItem component
/// <para>
///     <see href="https://bulma.io/documentation/components/navbar/" />
/// </para>
/// </summary>
public partial class NavbarItem : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.NavbarItem, true),
            (BulmaCssClass.HasDropdown, HasDropdown),
            (BulmaCssClass.IsHoverable, IsHoverable)
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
    /// Gets or sets the dropdown state.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the dropdown state.")]
    [Parameter]
    public bool HasDropdown { get; set; } = false;

    /// <summary>
    /// Gets or sets the href attribute to the link.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the <code>href</code> attribute to the link.")]
    [Parameter]
    public string? Href { get; set; } = null;

    /// <summary>
    /// Gets or sets the dropdown item hoverable state.
    /// <para>
    /// Default value is <see langword="true" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(true)]
    [Description("Gets or sets the dropdown item hoverable state.")]
    [Parameter]
    public bool IsHoverable { get; set; } = true;

    /// <summary>
    /// Gets or sets the navbar item type.
    /// <para>
    /// Default value is <see cref="NavbarItemType.Link" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(NavbarItemType.Link)]
    [Description("Gets or sets the navbar item type.")]
    [Parameter]
    public NavbarItemType Type { get; set; } = NavbarItemType.Link;

    #endregion
}
