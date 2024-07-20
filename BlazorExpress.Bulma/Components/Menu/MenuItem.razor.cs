namespace BlazorExpress.Bulma;

public partial class MenuItem : BulmaComponentBase
{
    #region Methods

    private void OnMenuItemClick() => Parent?.HideMenu();

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames => CssUtility.BuildClassNames(Class);

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the parent.
    /// </summary>
    [CascadingParameter]
    internal Menu Parent { get; set; } = default!;

    #endregion
}
