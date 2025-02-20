namespace BlazorExpress.Bulma;

public partial class NavbarBurger : BulmaComponentBase
{
    #region Methods

    private void OnNavbarBurgerClick()
    {
        if (ActiveStateChanged.HasDelegate)
            ActiveStateChanged.InvokeAsync(!IsActive);
        else
            IsActive = !IsActive;
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.NavbarBurger, true),
            (BulmaCssClass.IsLeft, IsLeft),
            (BulmaCssClass.IsActive, IsActive)
        );

    [Parameter] public EventCallback<bool> ActiveStateChanged { get; set; }

    /// <summary>
    /// Gets or sets the content to be rendered within the component.
    /// </summary>
    /// <remarks>
    /// Default value is null.
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

    [Parameter] public bool IsLeft { get; set; }

    /// <summary>
    /// Gets or sets the target id.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public string? TargetId { get; set; }

    #endregion
}
