namespace BlazorExpress.Bulma;

public partial class MessageHeader : BulmaComponentBase
{
    #region Methods

    private void CloseMessage() => Parent.CloseMessage();

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames => CssUtility.BuildClassNames(Class, (BulmaCssClass.MessageHeader, true));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [CascadingParameter] public Message Parent { get; set; } = default!;

    [CascadingParameter(Name = "ShowDeleteButton")] public bool ShowDeleteButton { get; set; } = true;

    #endregion
}
