namespace BlazorExpress.Bulma;

/// <summary>
/// Tag component
/// <see href="https://bulma.io/documentation/elements/tag/" />
/// </summary>
public partial class Tag : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Tag, true),
            (Color.ToTagColorClass(), true),
            (BulmaCssClass.IsLight, ShowLightVersion),
            (Size.ToTagSizeClass(), Size != TagSize.None),
            (BulmaCssClass.IsRounded, IsRounded),
            (BulmaCssClass.IsHoverable, IsHoverable),
            (BulmaCssClass.IsDelete, IsDelete)
        );

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="TagColor.None" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(TagColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter] public TagColor Color { get; set; } = TagColor.None;

    /// <summary>
    /// If <see langword="true"/>, the tag will converted to delete button.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the tag will converted to delete button.")]
    [Parameter] public bool IsDelete { get; set; } = false;

    /// <summary>
    /// If <see langword="true"/>, the tag will react to hover state. 
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the tag will react to hover state.")]
    [Parameter] public bool IsHoverable { get; set; } = false;

    /// <summary>
    /// If <see langword="true"/>, the rounded variant will be enabled.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the rounded variant will be enabled.")]
    [Parameter] public bool IsRounded { get; set; } = false;

    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(TagSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter] public TagSize Size { get; set; } = TagSize.None;

    /// <summary>
    /// If <see langword="true"/>, shows the color in its light version.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(NotificationColor.None)]
    [Description("If <b>true</b>, shows the color in its light version.")]
    [Parameter]
    public bool ShowLightVersion { get; set; } = false;

    #endregion
}
