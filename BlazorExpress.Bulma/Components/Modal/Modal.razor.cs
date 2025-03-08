namespace BlazorExpress.Bulma;

/// <summary>
/// Modal component
/// <para>
/// <see href="https://bulma.io/documentation/components/modal/" />
/// </para>
/// </summary>
public partial class Modal : BulmaComponentBase
{
    #region Methods

    public void Hide() => IsVisible = false;

    public void Show() => IsVisible = true;

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames => 
        BuildClassNames(
            Class, 
            (BulmaCssClass.Modal, true),
            (BulmaCssClass.IsActive, IsVisible)
        );

    /// <summary>
    /// Gets or sets the close button CSS class.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [Parameter]
    public string? CloseButtonCssClass { get; set; } = null;

    public string? CloseButtonClassNames =>
        BuildClassNames(
            CloseButtonCssClass,
            (BulmaCssClass.ModalClose, true)
        );

    /// <summary>
    /// If <see langword="true"/>, modal close button is hidden.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, modal close button is hidden.")]
    [Parameter]
    public bool HideCloseButton { get; set; } = false;

    /// <summary>
    /// If <see langword="true"/>, the modal is visible.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the modal is visible.")]
    [Parameter]
    public bool IsVisible { get; set; } = false;

    /// <summary>
    /// Gets or sets the modal content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the modal content.")]
    [Parameter]
    public RenderFragment? ModalContent { get; set; }

    #endregion
}
