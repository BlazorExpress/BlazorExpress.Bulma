namespace BlazorExpress.Bulma;

/// <summary>
/// CheckboxInput component
/// <para>
///     <see href="https://bulma.io/documentation/form/checkbox/" />
/// </para>
/// </summary>
public class CheckboxInput : BulmaComponentBase
{
    #region Fields and Constants

    private FieldIdentifier fieldIdentifier = default!;

    #endregion

    #region Methods

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(100, "label"); // open: label
        builder.AddAttributeIfNotNullOrWhiteSpace(101, "class", ClassNames);
        builder.AddAttributeIfNotNullOrWhiteSpace(102, "style", StyleNames);
        builder.AddAttribute(103, "disabled", Disabled);

        builder.OpenElement(200, "input"); // open: input
        builder.AddAttribute(201, "type", "checkbox");
        builder.AddAttributeIfNotNullOrWhiteSpace(202, "id", Id);
        builder.AddAttributeIfNotNullOrWhiteSpace(203, "class", FieldCssClasses);
        builder.AddAttribute(204, "checked", BindConverter.FormatValue(Value));
        builder.AddAttribute(205, "disabled", Disabled);
        builder.AddMultipleAttributes(206, AdditionalAttributes);
        builder.AddAttribute(207, "onchange", EventCallback.Factory.CreateBinder<bool>(this, OnChangeAsync, Value));
        builder.SetUpdatesAttributeName("checked");
        builder.AddElementReferenceCapture(208, inputReference => Element = inputReference);
        builder.CloseElement(); // close: input

        if (ChildContent is not null)
        {
            builder.AddContent(209, " ");
            builder.AddContent(210, ChildContent);
        }

        builder.CloseElement(); // close: label
    }

    protected override void OnInitialized()
    {
        AdditionalAttributes ??= new Dictionary<string, object>();

        base.OnInitialized();
    }

    protected override void OnParametersSet()
    {
        if (ValueExpression is not null)
            fieldIdentifier = FieldIdentifier.Create(ValueExpression);
    }

    /// <summary>
    /// Disables the <see cref="CheckboxInput" />.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Disables the <code>CheckboxInput</code>.")]
    public void Disable() => Disabled = true;

    /// <summary>
    /// Enables the <see cref="CheckboxInput" />.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Enables the <code>CheckboxInput</code>.")]
    public void Enable() => Disabled = false;

    private async Task OnChangeAsync(bool newValue)
    {
        if (ValueChanged.HasDelegate)
            await ValueChanged.InvokeAsync(newValue);
        else
            Value = newValue;

        if (ValueExpression is not null)
            EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames => BuildClassNames(Class, (BulmaCssClass.Checkbox, true));

    /// <summary>
    /// Gets or sets the checkbox label content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the checkbox label content.")]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the disabled state.
    /// <para>
    /// Default value is false.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the disabled state.")]
    [Parameter]
    public bool Disabled { get; set; }

    [CascadingParameter]
    private EditContext EditContext { get; set; } = default!;

    private string FieldCssClasses =>
        ValueExpression is not null
            ? EditContext?.FieldCssClass(fieldIdentifier) ?? string.Empty
            : string.Empty;

    /// <summary>
    /// Gets or sets the checked value.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the checked value.")]
    [Parameter]
    public bool Value { get; set; }

    /// <summary>
    /// This event fires when the <see cref="CheckboxInput" /> value changes.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("This event fires when the <code>CheckboxInput</code> value changes.")]
    [Parameter]
    public EventCallback<bool> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the expression.")]
    [ParameterTypeName("Expression<Func<bool>>?")]
    [Parameter]
    public Expression<Func<bool>>? ValueExpression { get; set; } = default!;

    #endregion
}
