namespace BlazorExpress.Bulma;

public partial class NavbarBurger : BulmaComponentBase
{
    #region Methods

    private void ToggleNavbarBurgerActiveState()
    {
        IsActive = !IsActive;

        if (NavbarBurgerActiveStateChanged.HasDelegate)
            NavbarBurgerActiveStateChanged.InvokeAsync(IsActive);
    }

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames => CssUtility.BuildClassNames(
        Class,
        (BulmaCssClass.NavbarBurger, true),
        (BulmaCssClass.IsActive, IsActive));

    /// <summary>
    /// Gets or sets the active state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="false"/>.
    /// </remarks>
    [Parameter]
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the target id.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public string? TargetId { get; set; }

    [Parameter]
    public EventCallback<bool> NavbarBurgerActiveStateChanged { get; set; }

    #endregion
}
