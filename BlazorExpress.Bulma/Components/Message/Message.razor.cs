namespace BlazorExpress.Bulma;

/// <summary>
/// Message component
/// <see href="https://bulma.io/documentation/components/message/" />
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

    protected override string? ClassNames => BuildClassNames(Class, (BulmaCssClass.Message, true));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// If <see langword="true" />, shows the delete button in the message header.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="true" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(true)]
    [Description("If <b>true</b>, shows the delete button in the message header.")]
    [Parameter]
    public bool ShowDeleteButton { get; set; } = true;

    /// <summary>
    /// Gets or sets the message visible state.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="true" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(true)]
    [Description("Gets or sets the message visible state.")]
    [Parameter]
    public bool Visible { get; set; } = true;

    #endregion
}
