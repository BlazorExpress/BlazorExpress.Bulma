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
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, icon color is applied to the text.")]
    [Parameter]
    public bool ApplyColorToText { get; set; }

    /// <summary>
    /// Gets or sets the bootstrap icon name.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="BootstrapIconName.None" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(BootstrapIconName.None)]
    [Description("Gets or sets the bootstrap icon name.")]
    [Parameter]
    public BootstrapIconName Name { get; set; } = BootstrapIconName.None;

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the icon color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconColor.None" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(IconColor.None)]
    [Description("Gets or sets the icon color.")]
    [Parameter]
    public IconColor Color { get; set; } = IconColor.None;

    private string? IconContainerCssClassNames =>
        BuildClassNames(
            (BulmaCssClass.Icon, true),
            (Color.ToIconColorClass(), Color != IconColor.None),
            (Size.ToIconSizeClass(), Size != IconSize.None),
            (BulmaCssClass.IsSkeleton, IsSkeleton)
        );

    /// <summary>
    /// If true, the skeleton variant will be enabled.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the skeleton variant will be enabled.")]
    [Parameter]
    public bool IsSkeleton { get; set; } = false;

    /// <summary>
    /// Gets or sets the icon size.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconSize.None" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(IconSize.None)]
    [Description("Gets or sets the icon size.")]
    [Parameter]
    public IconSize Size { get; set; } = IconSize.None;

    private string? TextCssClassNames =>
        BuildClassNames(
            (BulmaCssClass.IconText, true),
            (Color.ToIconColorClass(), Color != IconColor.None && ApplyColorToText)
        );

    #endregion
}
