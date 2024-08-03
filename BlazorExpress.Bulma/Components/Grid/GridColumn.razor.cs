namespace BlazorExpress.Bulma;

public partial class GridColumn<TItem> : BulmaComponentBase
{
    #region Fields and Constants

    private RenderFragment? cellTemplate;
    private RenderFragment? headerTemplate;

    #endregion

    #region Methods

    protected override void OnInitialized()
    {
        Parent.AddColumn(this);
    }

    #endregion

    #region Properties, Indexers

    [Parameter] public RenderFragment? CellTemplate { get; set; }

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment<TItem>? ChildContent { get; set; }

    // using this member to access in the grid component
    internal string? GridColumnCssClassNames => Class;

    // using this member to access in the grid component
    internal string? GridColumnCssStyleNames => Style;

    [Parameter] public RenderFragment? HeaderTemplate { get; set; }

    /// <summary>
    /// Gets or sets the table column header text.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public string HeaderText { get; set; } = default!;

    [CascadingParameter] public Grid<TItem> Parent { get; set; } = default!;

    /// <summary>
    /// Gets or sets the property name.
    /// This is required when `AllowFiltering` is true.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public string PropertyName { get; set; } = default!;

    internal string? ThClassNames => ThCssClass;

    [Parameter] public string? ThCssClass { get; set; }

    [Parameter] public string? ThCssStyle { get; set; }

    internal string? ThStyleNames => ThCssStyle;

    #endregion
}
