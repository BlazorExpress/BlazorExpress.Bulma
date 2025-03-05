namespace BlazorExpress.Bulma;

/// <summary>
/// Message component
/// <see href="https://bulma.io/documentation/components/message/" />
/// </summary>
public partial class Notification : BulmaComponentBase
{
    #region Methods

    internal void CloseNotification()
    {
        Visible = false;

        StateHasChanged();
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames => 
        BuildClassNames(
            Class, 
            (BulmaCssClass.Notification, true),
            (Color.ToNotificationColorClass(), true),
            (BulmaCssClass.IsLight, ShowLightColors)
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
    /// Gets or sets the color.
    /// <para>
    /// Default value is <see cref="NotificationColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(NotificationColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter] 
    public NotificationColor Color { get; set; } = NotificationColor.None;

    /// <summary>
    /// If <see langword="true"/>, shows the color in its light version.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(NotificationColor.None)]
    [Description("If <b>true</b>, shows the color in its light version.")]
    [Parameter]
    public bool ShowLightColors { get; set; } = false;

    /// <summary>
    /// If <see langword="true" />, shows the delete button.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, shows the delete button.")]
    [Parameter]
    public bool HideDeleteButton { get; set; } = false;

    /// <summary>
    /// If <see langword="true"/>, the notification is visible.
    /// <para>
    /// Default value is <see langword="true" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(true)]
    [Description("If <b>true</b>, the notification is visible.")]
    [Parameter]
    public bool Visible { get; set; } = true;

    #endregion
}
