namespace BlazorExpress.Bulma;

/// <summary>
/// Message component
/// <para>
///     <see href="https://bulma.io/documentation/components/message/" />
/// </para>
/// </summary>
public partial class Message : BulmaComponentBase
{
    #region Methods

    internal void CloseMessage()
    {
        Visible = false;

        StateHasChanged();
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Message, true),
            (Color.ToMessageColorClass(), true),
            (Size.ToMessageSizeClass(), Size != MessageSize.None)
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
    /// Default value is <see cref="MessageColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(MessageColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter]
    public MessageColor Color { get; set; } = MessageColor.None;

    /// <summary>
    /// If <see langword="true" />, shows the delete button in the message header.
    /// <para>
    /// Default value is <see langword="true" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(true)]
    [Description("If <b>true</b>, shows the delete button in the message header.")]
    [Parameter]
    public bool ShowDeleteButton { get; set; } = true;

    /// <summary>
    /// Gets or sets the size.
    /// <para>
    /// Default value is <see cref="MessageSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(MessageSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter]
    public MessageSize Size { get; set; } = MessageSize.None;

    /// <summary>
    /// Gets or sets the message visible state.
    /// <para>
    /// Default value is <see langword="true" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(true)]
    [Description("Gets or sets the message visible state.")]
    [Parameter]
    public bool Visible { get; set; } = true;

    #endregion
}
