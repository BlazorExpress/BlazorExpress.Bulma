namespace BlazorExpress.Bulma;

public partial class SimpleGridColumn : BulmaComponentBase
{
    #region Properties, Indexers

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion
}
