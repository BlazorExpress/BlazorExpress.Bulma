namespace BlazorExpress.Bulma;

public class GridColumn : BulmaComponentBase
{
    #region Fields and Constants

    private RenderFragment? cellTemplate;
    private RenderFragment? headerTemplate;

    #endregion

    #region Properties, Indexers

    internal RenderFragment CellTemplate => null;

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    internal RenderFragment HeaderTemplate => null;

    #endregion
}
