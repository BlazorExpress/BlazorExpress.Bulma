namespace BlazorExpress.Bulma;

/// <summary>
/// Component for Google Material Symbols and Icons.
/// <see href="https://icons.getbootstrap.com/" />
/// </summary>
public partial class BootstrapIcon : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BootstrapIconUtility.Icon(), Name != BootstrapIconName.None),
            (BootstrapIconUtility.Icon(Name), Name != BootstrapIconName.None)
        );

    /// <summary>
    /// If true, icon color is applied to the text.
    /// <para>
    /// The default value is <see cref="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, icon color is applied to the text.")]
    [Parameter]
    public bool ApplyColorToText { get; set; } = false;

    /// <summary>
    /// Gets or sets the bootstrap icon name.
    /// <para>
    /// Default value is <see cref="BootstrapIconName.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(BootstrapIconName.None)]
    [Description("Gets or sets the bootstrap icon name.")]
    [EditorRequired]
    [Parameter]
    public BootstrapIconName Name { get; set; } = BootstrapIconName.None;

    /// <summary>
    /// Gets or sets the child content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [Parameter]
    public RenderFragment? ChildContent { get; set; } = null;

    /// <summary>
    /// Gets or sets the icon color.
    /// <para>
    /// Default value is <see cref="BootstrapIconColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(BootstrapIconColor.None)]
    [Description("Gets or sets the icon color.")]
    [Parameter]
    public BootstrapIconColor Color { get; set; } = BootstrapIconColor.None;

    private string? IconContainerClassNames =>
        BuildClassNames(
            IconContainerCssClass,
            (BulmaCssClass.Icon, true),
            (Color.ToBootstrapIconColorClass(), Color != BootstrapIconColor.None),
            (Size.ToBootstrapIconSizeClass(), Size != BootstrapIconSize.None),
            (BulmaCssClass.IsSkeleton, IsSkeleton)
        );

    /// <summary>
    /// Gets or sets the CSS class for the icon container.
    /// <para>
    /// Default value is <see langword="null"/>.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS class for the icon container.")]
    [Parameter]
    public string? IconContainerCssClass { get; set; } = null;

    /// <summary>
    /// If true, the skeleton variant will be enabled.
    /// <para>
    /// The default value is <see cref="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the skeleton variant will be enabled.")]
    [Parameter]
    public bool IsSkeleton { get; set; } = false;

    /// <summary>
    /// Gets or sets the icon size.
    /// <para>
    /// Default value is <see cref="BootstrapIconSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(BootstrapIconSize.None)]
    [Description("Gets or sets the icon size.")]
    [Parameter]
    public BootstrapIconSize Size { get; set; } = BootstrapIconSize.None;

    private string? TextClassNames =>
        BuildClassNames(
            TextCssClass,
            (BulmaCssClass.IconText, true),
            (Color.ToBootstrapIconColorClass(), Color != BootstrapIconColor.None && ApplyColorToText)
        );

    /// <summary>
    /// Gets or sets the CSS class for the text.
    /// <para>
    /// Default value is <see langword="null"/>.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS class for the text.")]
    [Parameter]
    public string? TextCssClass { get; set; } = null;

    #endregion
}
