namespace BlazorExpress.Bulma;

/// <summary>
/// Modal component
/// <para>
/// <see href="https://bulma.io/documentation/components/modal/" />
/// </para>
/// </summary>
public partial class Modal : BulmaComponentBase
{
    private bool isVisible { get; set; } = false;

    #region Methods

    /// <summary>
    /// Hides the <see cref="Modal" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Hides the <code>Modal</code>.")]
    public void Hide()
    {
        isVisible = false;
        queuedTasks.Enqueue(async () => { await OnHidden.InvokeAsync(); });
    }

    /// <summary>
    /// Shows the <see cref="Modal" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Shows the <code>Modal</code>.")]
    public void Show()
    {
        isVisible = true;
        queuedTasks.Enqueue(async () => { await OnShown.InvokeAsync(); });
    }

    #endregion

    #region Properties, Indexers

    /// <summary>
    /// Gets or sets the child content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Modal, true),
            (BulmaCssClass.IsActive, isVisible)
        );

    /// <summary>
    /// Gets or sets the close button CSS class.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [Parameter]
    public string? CloseButtonCssClass { get; set; } = null;

    private string? CloseButtonClassNames =>
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
    /// This event fires when the <see cref="Modal" /> is hidden.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the <code>Modal</code> is hidden.")]
    [Parameter]
    public EventCallback OnHidden { get; set; }

    /// <summary>
    /// This event fires when the  <see cref="Modal" /> is shown.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the <code>Modal</code> is shown.")]
    [Parameter]
    public EventCallback OnShown { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public RenderFragment? TitleContent { get; set; }

    [Parameter]
    public string? TitleCssClass { get; set; }

    private string? TitleClassNames =>
        BuildClassNames(
            TitleCssClass,
            (BulmaCssClass.ModalCardTitle, true)
        );

    /// <summary>
    /// Gets or sets the modal body content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the modal body content.")]
    [Parameter]
    public RenderFragment? BodyContent { get; set; }

    [Parameter]
    public string? BodyCssClass { get; set; }

    private string? BodyClassNames =>
        BuildClassNames(
            BodyCssClass,
            (BulmaCssClass.ModalCardBody, true)
        );

    /// <summary>
    /// Gets or sets the modal foot content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the modal foot content.")]
    [Parameter]
    public RenderFragment? FootContent { get; set; }

    [Parameter]
    public string? FootCssClass { get; set; }

    private string? FootClassNames =>
        BuildClassNames(
            FootCssClass,
            (BulmaCssClass.ModalCardFoot, true)
        );

    #endregion
}
