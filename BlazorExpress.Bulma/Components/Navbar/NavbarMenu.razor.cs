namespace BlazorExpress.Bulma;

/// <summary>
/// NavbarMenu component
/// <para>
///     <see href="https://bulma.io/documentation/components/navbar/" />
/// </para>
/// </summary>
public partial class NavbarMenu : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.NavbarMenu, true),
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
    /// v
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the active state.")]
    [Parameter]
    public bool IsActive { get; set; } = false;

    #endregion
}
