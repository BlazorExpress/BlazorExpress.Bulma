namespace BlazorExpress.Bulma;

/// <summary>
/// <see href="https://bulma.io/documentation/components/tabs/" />
/// </summary>
public partial class Tabs : BulmaComponentBase
{
    #region Fields and Constants

    private Tab activeTab = default!;

    private bool isDefaultActiveTabSet = false;

    private List<Tab>? tabs = new();

    #endregion

    #region Methods

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(
            Class,
            (BulmaCssClass.Tabs, true),
            (Alignment.ToTabsAlignmentClass(), Alignment != TabsAlignment.None),
            (Size.ToTabsSizeClass(), Size != TabsSize.None),
            (Type.ToTabsTypeClass(), Type != TabsType.None),
            (BulmaCssClass.IsFullWidth, IsFullWidth));

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> alignment.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="TabsAlignment.None" />.
    /// </remarks>
    [Parameter]
    public TabsAlignment Alignment { get; set; }

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> width.
    /// If <see langword="true"/>, tabs will take up the whole width available.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool IsFullWidth { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> size.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="TabsSize.None" />.
    /// </remarks>
    [Parameter]
    public TabsSize Size { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="Tabs" /> type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="TabsType.None" />.
    /// </remarks>
    [Parameter]
    public TabsType Type { get; set; }

    #endregion
}
