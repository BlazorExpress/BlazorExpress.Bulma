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
            (Size.ToGoogleFontIconSizeClass(), Size != GoogleFontIconSize.None)
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
    /// Default value is <see cref="GoogleFontIconColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(GoogleFontIconColor.None)]
    [Description("Gets or sets the icon color.")]
    [Parameter]
    public GoogleFontIconColor Color { get; set; } = GoogleFontIconColor.None;

    private string? IconContainerClassNames =>
        BuildClassNames(
            IconContainerCssClass,
            (BulmaCssClass.Icon, true),
            (Color.ToGoogleFontIconColorClass(), Color != GoogleFontIconColor.None),
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
    /// Gets or sets the google font icon name.
    /// <para>
    /// Default value is <see cref="GoogleFontIconName.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(GoogleFontIconName.None)]
    [Description("Gets or sets the google font icon name.")]
    [EditorRequired]
    [Parameter]
    public GoogleFontIconName Name { get; set; } = GoogleFontIconName.None;

    /// <summary>
    /// Gets or sets the icon size.
    /// <para>
    /// Default value is <see cref="GoogleFontIconSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(GoogleFontIconSize.None)]
    [Description("Gets or sets the icon size.")]
    [Parameter]
    public GoogleFontIconSize Size { get; set; } = GoogleFontIconSize.None;

    /// <summary>
    /// Gets or sets the icon fill.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the icon fill.")]
    [Parameter]
    public bool Fill { get; set; } = false;

    private string? TextClassNames =>
        BuildClassNames(
            TextCssClass,
            (BulmaCssClass.IconText, true),
            (Color.ToGoogleFontIconColorClass(), Color != GoogleFontIconColor.None && ApplyColorToText)
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

    /// <summary>
    /// Gets or sets the google font icon style.
    /// <para>
    /// Default value is <see cref="GoogleFontIconStyle.Outlined" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(GoogleFontIconStyle.Outlined)]
    [Description("Gets or sets the google font icon style.")]
    [Parameter] 
    public GoogleFontIconStyle IconStyle { get; set; } = GoogleFontIconStyle.Outlined;

    #endregion
}
