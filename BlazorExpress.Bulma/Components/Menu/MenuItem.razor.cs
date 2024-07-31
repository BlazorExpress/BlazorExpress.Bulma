namespace BlazorExpress.Bulma;

public partial class MenuItem : BulmaComponentBase
{
    #region Methods

    protected override void Dispose(bool disposing) => base.Dispose(disposing);

    protected override void OnInitialized()
    {
        //NavigationManager.LocationChanged += NavigationManager_LocationChanged;
        base.OnInitialized();
    }

    private void NavigationManager_LocationChanged(object? sender, LocationChangedEventArgs e) { }

    private async Task OnMenuItemClick()
    {
        //IsActive = true; // TODO: remove this

        if (Parent is not null)
            await Parent.HideMenu();

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

    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    /// <summary>
    /// Gets or sets the parent.
    /// </summary>
    [CascadingParameter]
    internal Menu Parent { get; set; } = default!;

    #endregion
}
