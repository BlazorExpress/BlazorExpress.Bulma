namespace BlazorExpress.Bulma;

public partial class MenuItem : BulmaComponentBase
{
    #region Methods

    private void  OnMenuItemClick()
    {
        if (Parent is not null)
            Parent.HideMenu();

        // TODO: update IsActive
        // Additional scenario: Set IsActive based on the URL automatically
    }

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames =>
        CssUtility.BuildClassNames(
            Class,
            (BulmaCssClass.MenuItem, true),
            (BulmaCssClass.IsActive, IsActive)
        );

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the active state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false" />.
    /// </remarks>
    [Parameter]
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the parent.
    /// </summary>
    [CascadingParameter]
    internal Menu Parent { get; set; } = default!;

    #endregion
}
