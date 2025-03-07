namespace BlazorExpress.Bulma;

/// <summary>
/// Tag component
/// <see href="https://bulma.io/documentation/elements/tag/" />
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

    /// <summary>
    /// Gets or sets the parent.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the parent.")]
    [CascadingParameter]
    internal GroupedAddonTags Parent { get; set; } = default!;

    #endregion
}
