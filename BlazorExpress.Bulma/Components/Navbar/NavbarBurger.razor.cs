namespace BlazorExpress.Bulma;

/// <summary>
/// NavbarBurger component
/// <para>
///     <see href="https://bulma.io/documentation/components/navbar/" />
/// </para>
/// </summary>
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
    /// Gets or sets the child content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the active state.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the active state.")]
    [Parameter]
    public bool IsActive { get; set; } = false;

    /// <summary>
    /// If <see langword="true" />, sets the <see cref="NavbarBurger" /> to the left side.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, sets the <code>NavbarBurger</code> to the left side.")]
    [Parameter]
    public bool IsLeft { get; set; } = false;

    /// <summary>
    /// Gets or sets the target id.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the target id.")]
    [Parameter]
    public string? TargetId { get; set; } = null;

    #endregion
}
