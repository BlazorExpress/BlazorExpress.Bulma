namespace BlazorExpress.Bulma;

/// <summary>
/// Component for Google Material Symbols and Icons.
/// <see href="https://fonts.google.com/icons" />
/// </summary>
public partial class GoogleFontIcon : BulmaComponentBase
{
    private string IconName => GoogleFontIconUtility.ToIconName(Name);

    #region Properties, Indexers

    protected override string? CssClassNames =>
        CssUtility.BuildClassNames(
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
    [Parameter]
    public bool ApplyColorToText { get; set; }

    /// <summary>
    /// Gets or sets the google font icon name.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="GoogleFontIconName.None" />.
    /// </remarks>
    [Parameter]
    public GoogleFontIconName Name { get; set; } = GoogleFontIconName.None;

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

    /// <summary>
    /// Gets or sets the icon fill.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool Fill { get; set; }

    private string? TextCssClassNames =>
        CssUtility.BuildClassNames(
            (BulmaCssClass.IconText, true),
            (Color.ToIconColorClass(), Color != IconColor.None && ApplyColorToText)
        );

    /// <summary>
    /// Gets or sets the google font icon style.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="GoogleFontIconStyle.Outlined" />.
    /// </remarks>
    [Parameter] 
    public GoogleFontIconStyle IconStyle { get; set; } = GoogleFontIconStyle.Outlined;

    #endregion
}
