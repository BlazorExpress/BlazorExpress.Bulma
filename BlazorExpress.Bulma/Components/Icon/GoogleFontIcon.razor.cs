namespace BlazorExpress.Bulma;

/// <summary>
/// Component for Google Material Symbols and Icons.
/// <see href="https://fonts.google.com/icons" />
/// </summary>
public partial class GoogleFontIcon : BulmaComponentBase
{
    private string IconName => GoogleFontIconUtility.ToIconName(Name);

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (GoogleFontIconUtility.Icon(IconStyle), Name != GoogleFontIconName.None),
            (GoogleFontIconUtility.Icon(IconStyle), Name != GoogleFontIconName.None)
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
    public bool ApplyColorToText { get; set; } = false;

    /// <summary>
    /// Gets or sets the google font icon name.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="GoogleFontIconName.None" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(GoogleFontIconName.None)]
    [Description("Gets or sets the google font icon name.")]
    [Parameter]
    public GoogleFontIconName Name { get; set; } = GoogleFontIconName.None;

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

    /// <summary>
    /// Gets or sets the icon fill.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the icon fill.")]
    [Parameter]
    public bool Fill { get; set; } = false;

    private string? TextCssClassNames =>
        BuildClassNames(
            (BulmaCssClass.IconText, true),
            (Color.ToIconColorClass(), Color != IconColor.None && ApplyColorToText)
        );

    /// <summary>
    /// Gets or sets the google font icon style.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="GoogleFontIconStyle.Outlined" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(GoogleFontIconStyle.Outlined)]
    [Description("Gets or sets the google font icon style.")]
    [Parameter] 
    public GoogleFontIconStyle IconStyle { get; set; } = GoogleFontIconStyle.Outlined;

    #endregion
}
