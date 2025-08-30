namespace BlazorExpress.Bulma;

/// <summary>
/// Skeleton component
/// <para>
///     <see href="https://bulma.io/documentation/features/skeletons/" />
/// </para>
/// </summary>
public partial class Skeleton : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (Type.ToSkeletonTypeClass(), true),
            (Color.ToSkeletonColorClass(), Color != SkeletonColor.None)
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
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Skeleton" /> color.
    /// <para>
    /// Default value is <see cref="SkeletonColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(SkeletonColor.None)]
    [Description("Gets or sets the <code>Skeleton</code> color.")]
    [Parameter]
    public SkeletonColor Color { get; set; } = SkeletonColor.None;

    /// <summary>
    /// Gets or sets the <see cref="Skeleton" /> type.
    /// <para>
    /// Default value is <see cref="SkeletonType.Block" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(SkeletonType.Block)]
    [Description("Gets or sets the <code>Skeleton</code> type.")]
    [Parameter]
    public SkeletonType Type { get; set; } = SkeletonType.Block;

    #endregion
}
