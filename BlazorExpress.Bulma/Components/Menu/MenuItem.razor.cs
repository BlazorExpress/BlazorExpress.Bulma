namespace BlazorExpress.Bulma;

/// <summary>
/// MenuItem component
/// <para>
///     <see href="https://bulma.io/documentation/components/menu/" />
/// </para>
/// </summary>
public partial class MenuItem : BulmaComponentBase
{
    #region Methods

    private void OnMenuItemClick()
    {
        if (Parent is not null)
            Parent.HideMenu();

        // TODO: update IsActive
        // Additional scenario: Set IsActive based on the URL automatically
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            //(BulmaCssClass.MenuItem, true),
            (BulmaCssClass.IsActive, IsActive)
        );

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
    /// Gets or sets the parent.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [CascadingParameter]
    internal Menu Parent { get; set; } = default!;

    #endregion
}
