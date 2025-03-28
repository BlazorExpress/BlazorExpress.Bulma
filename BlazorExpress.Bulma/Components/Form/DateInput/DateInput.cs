namespace BlazorExpress.Bulma;

/// <summary>
/// TextInput component
/// <para>
///     <see href="https://bulma.io/documentation/form/input/" />
/// </para>
/// </summary>
public class DateInput : BulmaComponentBase
{
    #region Fields and Constants

    private FieldIdentifier fieldIdentifier = default!;

    #endregion

    #region Methods

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (State == TextInputState.Loading)
        {
            builder.OpenElement(100, "div"); // open div
            builder.AddAttributeIfNotNullOrWhiteSpace(101, "class", $"{BulmaCssClass.Control} {BulmaCssClass.IsLoading}");
        }

        builder.OpenElement(200, "input"); // open input
        builder.AddAttribute(201, "type", "date");
        builder.AddAttribute(202, "id", Id);
        builder.AddAttributeIfNotNullOrWhiteSpace(203, "class", $"{ClassNames} {FieldCssClasses}");
        builder.AddAttributeIfNotNullOrWhiteSpace(204, "style", StyleNames);
        builder.AddAttribute(205, "value", Value);
        builder.AddAttribute(206, "disabled", Disabled);
        builder.AddAttribute(207, "placeholder", Placeholder);
        builder.AddAttribute(208, "maxlength", MaxLength);
        builder.AddAttribute(209, "autocomplete", AutoCompleteAsString);
        builder.AddMultipleAttributes(210, AdditionalAttributes);

        if (BindEvent == BindEvent.OnChange)
            builder.AddAttribute(211, "onchange", OnChange);
        else if (BindEvent == BindEvent.OnInput)
            builder.AddAttribute(212, "oninput", OnInput);

        builder.AddElementReferenceCapture(213, __inputReference => Element = __inputReference);

        builder.CloseElement(); // close: input

        if (State == TextInputState.Loading)
            builder.CloseElement(); // close: div
    }

    protected override void OnInitialized()
    {
        AdditionalAttributes ??= new Dictionary<string, object>();

        fieldIdentifier = FieldIdentifier.Create(ValueExpression!);

        base.OnInitialized();
    }

    /// <summary>
    /// Disables the <see cref="TextInput" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Disables the <code>TextInput</code>.")]
    public void Disable() => Disabled = true;

    /// <summary>
    /// Enables the <see cref="TextInput" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Enables the <code>TextInput</code>.")]
    public void Enable() => Disabled = false;

    private async Task OnChange(ChangeEventArgs e)
    {
        var oldValue = Value;
        var newValue = e.Value?.ToString() ?? string.Empty; // object

        await ValueChanged.InvokeAsync(newValue);

        EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    private async Task OnInput(ChangeEventArgs e)
    {
        var oldValue = Value;
        var newValue = e.Value?.ToString() ?? string.Empty; // object

        await ValueChanged.InvokeAsync(newValue);

        EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Input, true),
            (Color.ToTextInputColorClass(), Color != TextInputColor.None),
            (TextAlignment.ToTextAlignmentClass(), TextAlignment != Alignment.None),
            (Size.ToTextInputSizeClass(), Size != TextInputSize.None),
            (BulmaCssClass.IsRounded, IsRounded),
            (State.ToTextInputStateClass(), State != TextInputState.None)
        );

    /// <summary>
    /// If <see langword="true" />, TextInput can complete the values automatically by the browser.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, <code>TextInput</code> can complete the values automatically by the browser.")]
    [Parameter]
    public bool AutoComplete { get; set; } = false;

    private string AutoCompleteAsString => AutoComplete ? "true" : "false";

    /// <summary>
    /// Gets or sets the input bind event.
    /// <para>
    /// Default value is <see cref="BindEvent.OnChange" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(BindEvent.OnChange)]
    [Description("Gets or sets the input bind event.")]
    [Parameter]
    public BindEvent BindEvent { get; set; } = BindEvent.OnChange;

    /// <summary>
    /// Gets or sets the color.
    /// <para>
    /// Default value is <see cref="TextInputColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(TextInputColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter]
    public TextInputColor Color { get; set; } = TextInputColor.None;

    /// <summary>
    /// Gets or sets the disabled state.
    /// <para>
    /// Default value is false.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the disabled state.")]
    [Parameter]
    public bool Disabled { get; set; } = false;

    [CascadingParameter] private EditContext EditContext { get; set; } = default!;

    private string FieldCssClasses => EditContext?.FieldCssClass(fieldIdentifier) ?? "";

    /// <summary>
    /// If true, the rounded variant will be enabled.
    /// <para>
    /// The default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the rounded variant will be enabled.")]
    [Parameter]
    public bool IsRounded { get; set; } = false;

    /// <summary>
    /// Gets or sets the maximum number of characters that can be entered.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the maximum number of characters that can be entered.")]
    [ParameterTypeName("int?")]
    [Parameter]
    public int? MaxLength { get; set; }

    /// <summary>
    /// Gets or sets the placeholder text.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the placeholder text.")]
    [Parameter]
    public string? Placeholder { get; set; } = null;

    /// <summary>
    /// Gets or sets the size.
    /// <para>
    /// Default value is <see cref="TextInputSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(TextInputSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter]
    public TextInputSize Size { get; set; } = TextInputSize.None;

    /// <summary>
    /// Gets or sets the state.
    /// <para>
    /// Default value is <see cref="TextInputState.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(TextInputState.None)]
    [Description("Gets or sets the state.")]
    [Parameter]
    public TextInputState State { get; set; } = TextInputState.None;

    /// <summary>
    /// Gets or sets the text alignment.
    /// <para>
    /// Default value is <see cref="Alignment.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(Alignment.None)]
    [Description("Gets or sets the text alignment.")]
    [Parameter]
    public Alignment TextAlignment { get; set; } = Alignment.None;

    /// <summary>
    /// Gets or sets the value.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the value.")]
    [Parameter]
    public string Value { get; set; } = default!;

    /// <summary>
    /// This event fires when the <see cref="TextInput" /> value changes.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the <code>TextInput</code> value changes.")]
    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the expression.")]
    [ParameterTypeName("Expression<Func<string>>?")]
    [Parameter]
    public Expression<Func<string>>? ValueExpression { get; set; } = default!;

    #endregion
}
