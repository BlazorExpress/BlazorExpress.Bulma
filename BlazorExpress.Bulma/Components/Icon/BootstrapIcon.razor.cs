namespace BlazorExpress.Bulma;

public partial class BootstrapIcon : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames =>
        CssUtility.BuildClassNames(
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
    [Parameter]
    public bool ApplyColorToText { get; set; }

    /// <summary>
    /// Gets or sets the bootstrap icon name.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="BootstrapIconName.None" />.
    /// </remarks>
    [Parameter]
    public BootstrapIconName Name { get; set; } = BootstrapIconName.None;

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the icon color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconColor.None" />.
    /// </remarks>
    [Parameter]
    public IconColor Color { get; set; } = IconColor.None;

    private string? IconContainerCssClassNames =>
        CssUtility.BuildClassNames(
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
    [Parameter]
    public bool IsSkeleton { get; set; }

    /// <summary>
    /// Gets or sets the icon size.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconSize.None" />.
    /// </remarks>
    [Parameter]
    public IconSize Size { get; set; } = IconSize.None;

    private string? TextCssClassNames =>
        CssUtility.BuildClassNames(
            (BulmaCssClass.IconText, true),
            (Color.ToIconColorClass(), Color != IconColor.None && ApplyColorToText)
        );

    #endregion
}
