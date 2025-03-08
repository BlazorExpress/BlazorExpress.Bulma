namespace BlazorExpress.Bulma;

/// <summary>
/// Skeleton component
/// <para>
/// <see href="https://bulma.io/documentation/features/skeletons/" />
/// </para>
/// </summary>
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

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (Color.ToSkeletonColorClass(), Color != SkeletonColor.None)
        );

    protected override string? StyleNames =>
        BuildStyleNames(
            Style,
            ($"width: {Width.ToString(CultureInfo.InvariantCulture)}%", Width > 0)
        );

    /// <summary>
    /// Gets or sets the <see cref="SkeletonLine" /> color.
    /// <para>
    /// Default value is <see cref="SkeletonColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(SkeletonColor.None)]
    [Description("Gets or sets the <code>SkeletonLine</code> color.")]
    [Parameter]
    public SkeletonColor Color { get; set; } = SkeletonColor.None;

    /// <summary>
    /// Gets or sets the <see cref="SkeletonLine" /> width.
    /// <para>
    /// Default value is 100.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(100)]
    [Description("Gets or sets the <code>SkeletonLine</code> width.")]
    [Parameter]
    public float Width { get; set; } = 100;

    #endregion
}
