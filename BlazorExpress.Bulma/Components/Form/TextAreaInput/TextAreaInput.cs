namespace BlazorExpress.Bulma;

/// <summary>
/// TextAreaInput component
/// <para>
///     <see href="https://bulma.io/documentation/form/textarea/" />
/// </para>
/// </summary>
public class TextAreaInput : BulmaComponentBase
{
    #region Fields and Constants

    private FieldIdentifier fieldIdentifier = default!;

    #endregion

    #region Methods

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (State == TextAreaInputState.Loading)
        {
            builder.OpenElement(100, "div"); // open div
            builder.AddAttributeIfNotNullOrWhiteSpace(101, "class", LoadingControlClassNames);
        }

        builder.OpenElement(200, "textarea"); // open textarea
        builder.AddAttribute(201, "id", Id);
        builder.AddAttributeIfNotNullOrWhiteSpace(202, "class", $"{ClassNames} {FieldCssClasses}");
        builder.AddAttributeIfNotNullOrWhiteSpace(203, "style", StyleNames);
        builder.AddAttribute(204, "value", Value);
        builder.AddAttribute(205, "disabled", Disabled);
        builder.AddAttribute(206, "readonly", ReadOnly);
        builder.AddAttribute(207, "placeholder", Placeholder);
        builder.AddAttribute(208, "maxlength", MaxLength);
        builder.AddAttribute(209, "rows", Rows);
        builder.AddMultipleAttributes(210, AdditionalAttributes);

        if (BindEvent == BindEvent.OnChange)
            builder.AddAttribute(211, "onchange", OnChange);
        else if (BindEvent == BindEvent.OnInput)
            builder.AddAttribute(212, "oninput", OnInput);

        builder.AddElementReferenceCapture(213, __inputReference => Element = __inputReference);

        builder.CloseElement(); // close: textarea

        if (State == TextAreaInputState.Loading)
            builder.CloseElement(); // close: div
    }

    protected override void OnInitialized()
    {
        AdditionalAttributes ??= new Dictionary<string, object>();

        fieldIdentifier = FieldIdentifier.Create(ValueExpression!);

        base.OnInitialized();
    }

    protected override void OnParametersSet()
    {
        if (Rows.HasValue && Rows.Value < 1)
            throw new InvalidOperationException($"{nameof(TextAreaInput)} requires {nameof(Rows)} to be greater than 0.");

        base.OnParametersSet();
    }

    /// <summary>
    /// Disables the <see cref="TextAreaInput" />.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Disables the <code>TextAreaInput</code>.")]
    public void Disable() => Disabled = true;

    /// <summary>
    /// Enables the <see cref="TextAreaInput" />.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Enables the <code>TextAreaInput</code>.")]
    public void Enable() => Disabled = false;

    private async Task OnChange(ChangeEventArgs e)
    {
        var newValue = e.Value?.ToString() ?? string.Empty;

        await ValueChanged.InvokeAsync(newValue);

        EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    private async Task OnInput(ChangeEventArgs e)
    {
        var newValue = e.Value?.ToString() ?? string.Empty;

        await ValueChanged.InvokeAsync(newValue);

        EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Textarea, true),
            (Color.ToTextAreaInputColorClass(), Color != TextAreaInputColor.None),
            (Size.ToTextAreaInputSizeClass(), Size != TextAreaInputSize.None),
            (State.ToTextAreaInputStateClass(), State != TextAreaInputState.None),
            (BulmaCssClass.HasFixedSize, IsFixedSize)
        );

    private string? LoadingControlClassNames =>
        BuildClassNames(
            null,
            (BulmaCssClass.Control, true),
            (BulmaCssClass.IsLoading, true),
            (BulmaCssClass.IsSmall, Size == TextAreaInputSize.Small),
            (BulmaCssClass.IsMedium, Size == TextAreaInputSize.Medium),
            (BulmaCssClass.IsLarge, Size == TextAreaInputSize.Large)
        );

    /// <summary>
    /// Gets or sets the input bind event.
    /// <para>
    /// Default value is <see cref="BindEvent.OnChange" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(BindEvent.OnChange)]
    [Description("Gets or sets the input bind event.")]
    [Parameter]
    public BindEvent BindEvent { get; set; } = BindEvent.OnChange;

    /// <summary>
    /// Gets or sets the color.
    /// <para>
    /// Default value is <see cref="TextAreaInputColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(TextAreaInputColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter]
    public TextAreaInputColor Color { get; set; } = TextAreaInputColor.None;

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

    private string FieldCssClasses => EditContext?.FieldCssClass(fieldIdentifier) ?? "";

    /// <summary>
    /// Gets or sets a value indicating whether textarea resizing is disabled.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("Gets or sets a value indicating whether textarea resizing is disabled.")]
    [Parameter]
    public bool IsFixedSize { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of characters that can be entered.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
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
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the placeholder text.")]
    [Parameter]
    public string? Placeholder { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the textarea is read-only.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("Gets or sets a value indicating whether the textarea is read-only.")]
    [Parameter]
    public bool ReadOnly { get; set; }

    /// <summary>
    /// Gets or sets the number of visible text lines.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the number of visible text lines.")]
    [ParameterTypeName("int?")]
    [Parameter]
    public int? Rows { get; set; }

    /// <summary>
    /// Gets or sets the size.
    /// <para>
    /// Default value is <see cref="TextAreaInputSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(TextAreaInputSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter]
    public TextAreaInputSize Size { get; set; } = TextAreaInputSize.None;

    /// <summary>
    /// Gets or sets the state.
    /// <para>
    /// Default value is <see cref="TextAreaInputState.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(TextAreaInputState.None)]
    [Description("Gets or sets the state.")]
    [Parameter]
    public TextAreaInputState State { get; set; } = TextAreaInputState.None;

    /// <summary>
    /// Gets or sets the value.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the value.")]
    [Parameter]
    public string Value { get; set; } = default!;

    /// <summary>
    /// This event fires when the <see cref="TextAreaInput" /> value changes.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("This event fires when the <code>TextAreaInput</code> value changes.")]
    [Parameter]
    public EventCallback<string> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the expression.")]
    [ParameterTypeName("Expression<Func<string>>?")]
    [Parameter]
    public Expression<Func<string>>? ValueExpression { get; set; } = default!;

    #endregion
}
