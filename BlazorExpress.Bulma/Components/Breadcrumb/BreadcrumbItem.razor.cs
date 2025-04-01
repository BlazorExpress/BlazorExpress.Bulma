namespace BlazorExpress.Bulma;

/// <summary>
/// Breadcrumb item component
/// <para>
/// <see href="https://bulma.io/documentation/components/breadcrumb/" />
/// </para>
/// </summary>
public partial class BreadcrumbItem : BulmaComponentBase
{
    private string? areaCurrent => IsActive ? "page" : null;

    #region Properties, Indexers

    protected override string? ClassNames => 
        BuildClassNames(
            Class, 
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

    /// <summary>
    /// Gets or sets the href.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the href.")]
    [Parameter]
    public string? Href { get; set; }

    /// <summary>
    /// If <see langword="true" />, the item will be shown as active.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("If <b>true</b>, the item will be shown as active.")]
    [Parameter]
    public bool IsActive { get; set; } = false;

    #endregion
}
