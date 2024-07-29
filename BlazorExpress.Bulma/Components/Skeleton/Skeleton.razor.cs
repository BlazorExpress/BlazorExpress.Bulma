namespace BlazorExpress.Bulma;

/// <summary>
/// <see href="https://bulma.io/documentation/features/skeletons/" />
/// </summary>
public partial class Skeleton : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(
            Class, 
            (Type.ToSkeletonTypeClass(), true),
            (Color.ToSkeletonColorClass(), Color != SkeletonColor.None));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Skeleton" /> color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="SkeletonColor.None" />.
    /// </remarks>
    [Parameter]
    public SkeletonColor Color { get; set; }

    [Parameter]
    public SkeletonType Type { get; set; } = SkeletonType.Block;

    #endregion
}
