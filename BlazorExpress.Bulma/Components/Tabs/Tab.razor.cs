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

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            ("tab-content", true),
            (BulmaCssClass.IsActive, IsActive)
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

    public string? CssClass => ClassNames;

    /// <summary>
    /// Gets or sets the active state.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the active state.")]
    [Parameter]
    public bool IsActive { get; set; } = false;

    /// <summary>
    /// Gets or sets the disabled state.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the disabled state.")]
    [Parameter]
    public bool IsDisabled { get; set; } = false;

    /// <summary>
    /// Gets or sets the tab name.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the tab name.")]
    [Parameter]
    public string? Name { get; set; } = null;

    /// <summary>
    /// Gets or sets the parent.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [CascadingParameter]
    internal Tabs? Parent { get; set; }

    /// <summary>
    /// Gets or sets the tab title.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the tab title.")]
    [Parameter]
    public string? Title { get; set; } = null;

    /// <summary>
    /// Gets or sets the tab title template.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the tab title template.")]
    [Parameter]
    public RenderFragment? TitleTemplate { get; set; }

    #endregion
}
