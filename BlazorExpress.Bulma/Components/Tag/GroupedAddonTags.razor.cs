namespace BlazorExpress.Bulma;

/// <summary>
/// Tag component
/// <see href="https://bulma.io/documentation/elements/tag/" />
/// </summary>
public partial class GroupedAddonTags : BulmaComponentBase
{
    #region Fields and Constants

    private List<AddonTags>? items = new();

    #endregion

    #region Methods

    internal void Add(AddonTags item)
    {
        if (items is null)
            items = new List<AddonTags>();

        if (item is not null)
            items.Add(item);
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Field, true),
            (BulmaCssClass.IsGrouped, true),
            (BulmaCssClass.IsGroupedMultiline, true)
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
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion
}
