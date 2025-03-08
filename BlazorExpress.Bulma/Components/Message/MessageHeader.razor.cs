namespace BlazorExpress.Bulma;

/// <summary>
/// MessageHeader component
/// <para>
/// <see href="https://bulma.io/documentation/components/message/" />
/// </para>
/// </summary>
public partial class MessageHeader : BulmaComponentBase
{
    #region Methods

    private void CloseMessage() => Parent.CloseMessage();

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames => BuildClassNames(Class, (BulmaCssClass.MessageHeader, true));

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

    [CascadingParameter] 
    public Message Parent { get; set; } = default!;

    [CascadingParameter(Name = "ShowDeleteButton")] 
    public bool ShowDeleteButton { get; set; } = true;

    #endregion
}
