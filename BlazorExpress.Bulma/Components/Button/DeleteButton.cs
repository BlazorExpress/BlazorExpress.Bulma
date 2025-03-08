namespace BlazorExpress.Bulma;

/// <summary>
/// DeleteButton component
/// <para>
/// <see href="https://bulma.io/documentation/elements/delete/" />
/// </para>
/// </summary>
public partial class DeleteButton : BulmaComponentBase
{

    #region Methods

    protected override void OnInitialized()
    {
        AdditionalAttributes ??= new Dictionary<string, object>();

        base.OnInitialized();
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(200, "button"); // open button
        builder.AddAttribute(202, "id", Id);
        builder.AddAttributeIfNotNullOrWhiteSpace(203, "class", ClassNames);
        builder.AddAttributeIfNotNullOrWhiteSpace(204, "style", StyleNames);
        builder.AddMultipleAttributes(210, AdditionalAttributes);

        builder.AddElementReferenceCapture(213, __inputReference => Element = __inputReference);

        builder.CloseElement(); // close: button
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Delete, true),
            (Size.ToDeleteButtonSizeClass(), Size != DeleteButtonSize.None)
        );

    /// <summary>
    /// Gets or sets the size.
    /// <para>
    /// Default value is <see cref="DeleteButtonSize.None" />
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(DeleteButtonSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter] public DeleteButtonSize Size { get; set; } = DeleteButtonSize.None;

    #endregion
}
