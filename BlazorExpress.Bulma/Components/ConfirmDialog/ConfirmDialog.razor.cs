﻿namespace BlazorExpress.Bulma;

/// <summary>
/// ConfirmDialog component
/// <para>
///     <see href="https://bulma.io/documentation/components/modal/" />
/// </para>
/// </summary>
public partial class ConfirmDialog : BulmaComponentBase
{
    #region Fields and Constants

    private string? bodyCssClass;
    private string? footCssClass;
    private string? message = null;
    private string? messageHtml = null;

    private TaskCompletionSource<bool>? taskCompletionSource;
    private string? title = null;

    private string? titleCssClass;
    private string? titleHtml = null;

    #endregion

    #region Methods

    public Task<bool> ShowAsync(
        string? title = null,
        string? titleHtml = null,
        string? message = null,
        string? messageHtml = null,
        ConfirmDialogOptions? options = null
    )
    {
        taskCompletionSource = new TaskCompletionSource<bool>();
        var task = taskCompletionSource.Task;

        this.title = title;
        this.titleHtml = titleHtml;
        this.message = message;
        this.messageHtml = messageHtml;

        if (options is null)
            options = new ConfirmDialogOptions();

        titleCssClass = options.TitleCssClass;
        bodyCssClass = options.BodyCssClass;
        footCssClass = options.FootCssClass;

        yesButtonText = options.YesButtonText;
        yesButtonColor = options.YesButtonColor;
        yesButtonCssClass = options.YesButtonCssClass;
        noButtonText = options.NoButtonText;
        noButtonColor = options.NoButtonColor;
        noButtonCssClass = options.NoButtonCssClass;

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

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Modal, true),
            (BulmaCssClass.IsActive, isVisible)
        );

    private string? BodyClassNames =>
        BuildClassNames(
            bodyCssClass,
            (BulmaCssClass.ModalCardBody, true)
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
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private string? FootClassNames =>
        BuildClassNames(
            footCssClass,
            (BulmaCssClass.ModalCardFoot, true)
        );

    /// <summary>
    /// If <see langword="true" />, confirm modal close button is hidden.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, confirm modal close button is hidden.")]
    [Parameter]
    public bool HideCloseButton { get; set; } = false;

    private bool isVisible { get; set; } = false;

    private string? NoButtonClassNames =>
        BuildClassNames(
            noButtonCssClass,
            (BulmaCssClass.Button, true),
            (noButtonColor.ToButtonColorClass(), noButtonColor != ButtonColor.None)
        );

    private ButtonColor noButtonColor { get; set; } = ButtonColor.None;
    private string? noButtonCssClass { get; set; }
    private string noButtonText { get; set; } = "No";

    private string? TitleClassNames =>
        BuildClassNames(
            titleCssClass,
            (BulmaCssClass.ModalCardTitle, true)
        );

    private string? YesButtonClassNames =>
        BuildClassNames(
            yesButtonCssClass,
            (BulmaCssClass.Button, true),
            (yesButtonColor.ToButtonColorClass(), yesButtonColor != ButtonColor.None)
        );

    private ButtonColor yesButtonColor { get; set; } = ButtonColor.Primary;
    private string? yesButtonCssClass { get; set; }

    private string yesButtonText { get; set; } = "Yes";

    #endregion
}
