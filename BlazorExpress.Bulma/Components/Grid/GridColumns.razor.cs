namespace BlazorExpress.Bulma;

public partial class GridColumns : BulmaComponentBase
{
    /// <summary>
    /// Specifies the content to be rendered inside the grid columns component.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; } = default!;
}
