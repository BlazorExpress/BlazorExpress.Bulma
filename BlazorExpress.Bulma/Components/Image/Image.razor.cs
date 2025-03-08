namespace BlazorExpress.Bulma;

/// <summary>
/// Image component
/// <see href="https://bulma.io/documentation/elements/image/" />
/// </summary>
public partial class Image : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames => 
        BuildClassNames(
            Class, 
            (BulmaCssClass.Block, true),
            (BulmaCssClass.IsRounded, IsRounded)
        );

    /// <summary>
    /// Gets or sets the image dimension.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(ImageDimension.None)]
    [Description("Gets or sets the image dimension.")]
    [Parameter]
    public ImageDimension Dimension { get; set; } = ImageDimension.None;

    /// <summary>
    /// Gets or sets the figure CSS class.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the figure CSS class.")]
    [Parameter]
    public string? FigureCssClass { get; set; }

    private string? FigureCssClassNames => 
        BuildClassNames(
            FigureCssClass,
            (BulmaCssClass.Image, true),
            (Ratio.ToImageRatioClass(), Ratio != ImageRatio.None),
            (Dimension.ToImageDimensionClass(), Dimension != ImageDimension.None)
        );

    /// <summary>
    /// Gets or sets the figure CSS style.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the figure CSS style.")]
    [Parameter]
    public string? FigureCssStyle { get; set; }

    private string? FigureCssStyleNames => FigureCssStyle;

    /// <summary>
    /// If true, image will be rounded.
    /// <para>
    /// The default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, image will be rounded.")]
    [Parameter] 
    public bool IsRounded { get; set; } = false;

    /// <summary>
    /// Gets or sets the image ratio.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(ImageRatio.None)]
    [Description("Gets or sets the image ratio.")]
    [Parameter]
    public ImageRatio Ratio { get; set; } = ImageRatio.None;

    /// <summary>
    /// Gets or sets the image src.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the image src.")]
    [EditorRequired]
    [Parameter]
    public string? Src { get; set; }

    #endregion
}
