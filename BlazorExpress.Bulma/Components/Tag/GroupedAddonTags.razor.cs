namespace BlazorExpress.Bulma;

/// <summary>
/// GroupedAddonTags component
/// <para>
///     <see href="https://bulma.io/documentation/elements/tag/" />
/// </para>
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
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion
}
