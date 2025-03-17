namespace BlazorExpress.Bulma;

/// <summary>
/// AddonTags component
/// <para>
///     <see href="https://bulma.io/documentation/elements/tag/" />
/// </para>
/// </summary>
public partial class AddonTags : BulmaComponentBase
{
    #region Methods

    protected override void OnInitialized()
    {
        Id = Id ?? IdUtility.GetNextId(); // This is required

        if (Parent is not null)
            Parent.Add(this);
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Tags, true),
            (BulmaCssClass.HasAddons, true)
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

    /// <summary>
    /// Gets or sets the parent.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the parent.")]
    [CascadingParameter]
    internal GroupedAddonTags Parent { get; set; } = default!;

    #endregion
}
