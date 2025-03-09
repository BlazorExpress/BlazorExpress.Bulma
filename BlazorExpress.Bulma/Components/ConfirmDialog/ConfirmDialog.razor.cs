namespace BlazorExpress.Bulma;

/// <summary>
/// ConfirmDialog component
/// <para>
/// <see href="https://bulma.io/documentation/components/modal/" />
/// </para>
/// </summary>
public partial class ConfirmDialog : BulmaComponentBase
{
    private string? title = null;
    private string? titleHtml = null;
    private string? message = null;
    private string? messageHtml = null;
    private string yesButtonText { get; set; } = "Yes";
    private string? yesButtonCssClass { get; set; }
    private string noButtonText { get; set; } = "No";
    private string? noButtonCssClass { get; set; }
    private bool isVisible { get; set; } = false;

    private TaskCompletionSource<bool>? taskCompletionSource;

    #region Methods

    public Task<bool> ShowAsync(
        string? title = null,
        string? titleHtml = null,
        string? message = null,
        string? messageHtml = null)
    {
        taskCompletionSource = new TaskCompletionSource<bool>();
        var task = taskCompletionSource.Task;

        this.title = title;
        this.titleHtml = titleHtml;
        this.message = message;
        this.messageHtml = messageHtml;
        isVisible = true;

        StateHasChanged();

        return task;
    }

    private void OnNoClick()
    {
        isVisible = false;
        taskCompletionSource?.SetResult(false);
    }

    private void OnYesClick()
    {
        isVisible = false;
        taskCompletionSource?.SetResult(true);
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

    [Parameter]
    public string? TitleCssClass { get; set; }

    private string? TitleClassNames =>
        BuildClassNames(
            TitleCssClass,
            (BulmaCssClass.ModalCardTitle, true)
        );

    [Parameter]
    public string? BodyCssClass { get; set; }

    private string? BodyClassNames =>
        BuildClassNames(
            BodyCssClass,
            (BulmaCssClass.ModalCardBody, true)
        );

    [Parameter]
    public string? FootCssClass { get; set; }

    private string? FootClassNames =>
        BuildClassNames(
            FootCssClass,
            (BulmaCssClass.ModalCardFoot, true)
        );

    #endregion
}
