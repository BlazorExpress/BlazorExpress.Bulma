namespace BlazorExpress.Bulma;

public partial class SkeletonLine : BulmaComponentBase
{
    #region Methods

    protected override void OnParametersSet()
    {
        if (Width < 0 || Width > 100)
            throw new ArgumentOutOfRangeException(nameof(Width), "Width must be between 0 and 100.");

        base.OnParametersSet();
    }

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames =>
        CssUtility.BuildClassNames(
            Class,
            (Color.ToSkeletonColorClass(), Color != SkeletonColor.None)
        );

    protected override string? CssStyleNames =>
        CssUtility.BuildStyleNames(
            Style,
            ($"width: {Width.ToString(CultureInfo.InvariantCulture)}%", Width > 0)
        );

    /// <summary>
    /// Gets or sets the <see cref="SkeletonLine" /> color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="SkeletonColor.None" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(SkeletonColor.None)]
    [Description("Gets or sets the <code>SkeletonLine</code> color.")]
    [Parameter]
    public SkeletonColor Color { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="SkeletonLine" /> width.
    /// </summary>
    /// <remarks>
    /// Default value is 100.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(100)]
    [Description("Gets or sets the <code>SkeletonLine</code> width.")]
    [Parameter]
    public float Width { get; set; } = 100;

    #endregion
}
