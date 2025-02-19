namespace BlazorExpress.Bulma;

/// <summary>
/// Tab component
/// <see href="https://bulma.io/documentation/components/tabs/" />
/// </summary>
public partial class Tab : BulmaComponentBase
{
    #region Methods

    protected override void OnInitialized()
    {
        Id = IdUtility.GetNextId(); // This is required
        Parent?.AddTab(this);
    }

    internal void Hide() => IsActive = false;

    internal void Show() => IsActive = true;

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames =>
        CssUtility.BuildClassNames(
            Class,
            ("tab-content", true),
            (BulmaCssClass.IsActive, IsActive)
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

    public string? CssClass => CssClassNames;

    /// <summary>
    /// Gets or sets the active state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the active state.")]
    [Parameter]
    public bool IsActive { get; set; } = false;

    /// <summary>
    /// Gets or sets the disabled state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the disabled state.")]
    [Parameter]
    public bool IsDisabled { get; set; } = false;

    /// <summary>
    /// Gets or sets the tab name.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the tab name.")]
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the parent.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [CascadingParameter]
    internal Tabs? Parent { get; set; }

    /// <summary>
    /// Gets or sets the tab title.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the tab title.")]
    [Parameter]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the tab title template.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the tab title template.")]
    [Parameter]
    public RenderFragment? TitleTemplate { get; set; }

    #endregion
}
