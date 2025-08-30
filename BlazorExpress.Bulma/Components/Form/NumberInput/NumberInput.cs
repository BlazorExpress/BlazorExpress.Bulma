using System.Numerics;

namespace BlazorExpress.Bulma;

/// <summary>
/// NumberInput component
/// <para>
///     <see href="https://bulma.io/documentation/form/input/" />
/// </para>
/// </summary>
public class NumberInput<TValue> : BulmaComponentBase
{
    #region Fields and Constants

    private CultureInfo cultureInfo = default!;

    private FieldIdentifier fieldIdentifier = default!;

    private string step => Step.HasValue
                            ? Step.Value.ToString(CultureInfo.InvariantCulture)
                            : "any";

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
        builder.AddAttribute(201, "type", "number");
        builder.AddAttribute(202, "id", Id);
        builder.AddAttributeIfNotNullOrWhiteSpace(203, "class", $"{ClassNames} {FieldCssClasses}");
        builder.AddAttributeIfNotNullOrWhiteSpace(204, "style", StyleNames);
        builder.AddAttribute(205, "value", Value);
        //if(EnableMinMax)
        //{
        //    if (!EqualityComparer<TValue>.Default.Equals(Min, default!))
        //        builder.AddAttribute(206, "min", Min.ToString(CultureInfo.InvariantCulture));

        //    if (!EqualityComparer<TValue>.Default.Equals(Max, default!))
        //        builder.AddAttribute(207, "max", Max.ToString(CultureInfo.InvariantCulture));
        //}
        builder.AddAttribute(208, "step", step);
        builder.AddAttribute(209, "disabled", Disabled);
        builder.AddAttribute(210, "placeholder", Placeholder);
        builder.AddAttribute(211, "maxlength", MaxLength);
        builder.AddAttribute(212, "autocomplete", AutoCompleteAsString);
        builder.AddMultipleAttributes(213, AdditionalAttributes);

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
        if (!(typeof(TValue) == typeof(sbyte)
              || typeof(TValue) == typeof(sbyte?)
              || typeof(TValue) == typeof(short)
              || typeof(TValue) == typeof(short?)
              || typeof(TValue) == typeof(int)
              || typeof(TValue) == typeof(int?)
              || typeof(TValue) == typeof(long)
              || typeof(TValue) == typeof(long?)
              || typeof(TValue) == typeof(float)
              || typeof(TValue) == typeof(float?)
              || typeof(TValue) == typeof(double)
              || typeof(TValue) == typeof(double?)
              || typeof(TValue) == typeof(decimal)
              || typeof(TValue) == typeof(decimal?)
             ))
            throw new InvalidOperationException($"{typeof(TValue)} is not supported.");

        AdditionalAttributes ??= new Dictionary<string, object>();

        fieldIdentifier = FieldIdentifier.Create(ValueExpression!);

        try
        {
            cultureInfo = new CultureInfo(Locale);
        }
        catch (CultureNotFoundException)
        {
            cultureInfo = new CultureInfo("en-US");
        }

        base.OnInitialized();
    }

    /// <summary>
    /// Disables the <see cref="NumberInput<TValue>" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Disables the <code>NumberInput<TValue></code>.")]
    public void Disable() => Disabled = true;

    /// <summary>
    /// Enables the <see cref="NumberInput<TValue>" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Enables the <code>NumberInput<TValue></code>.")]
    public void Enable() => Disabled = false;

    private async Task OnChange(ChangeEventArgs e)
    {
        var oldValue = Value;
        var newValue = e.Value; // object

        //await ValueChanged.InvokeAsync(newValue);

        EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    private async Task OnInput(ChangeEventArgs e)
    {
        var oldValue = Value;
        var newValue = e.Value?.ToString() ?? string.Empty; // object

        //await ValueChanged.InvokeAsync(newValue);

        EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    private bool TryParseValue(object value, out TValue newValue)
    {
        try
        {
            // sbyte? / sbyte
            if (typeof(TValue) == typeof(sbyte?) || typeof(TValue) == typeof(sbyte))
            {
                newValue = (TValue)Convert.ChangeType(value, typeof(sbyte));

                return true;
            }
            // short? / short

            if (typeof(TValue) == typeof(short?) || typeof(TValue) == typeof(short))
            {
                newValue = (TValue)Convert.ChangeType(value, typeof(short));

                return true;
            }
            // int? / int

            if (typeof(TValue) == typeof(int?) || typeof(TValue) == typeof(int))
            {
                newValue = (TValue)Convert.ChangeType(value, typeof(int));

                return true;
            }
            // long? / long

            if (typeof(TValue) == typeof(long?) || typeof(TValue) == typeof(long))
            {
                newValue = (TValue)Convert.ChangeType(value, typeof(long));

                return true;
            }
            // float? / float

            if (typeof(TValue) == typeof(float?) || typeof(TValue) == typeof(float))
            {
                newValue = (TValue)Convert.ChangeType(value, typeof(float), CultureInfo.InvariantCulture);

                return true;
            }
            // double? / double

            if (typeof(TValue) == typeof(double?) || typeof(TValue) == typeof(double))
            {
                newValue = (TValue)Convert.ChangeType(value, typeof(double), CultureInfo.InvariantCulture);

                return true;
            }
            // decimal? / decimal

            if (typeof(TValue) == typeof(decimal?) || typeof(TValue) == typeof(decimal))
            {
                newValue = (TValue)Convert.ChangeType(value, typeof(decimal), CultureInfo.InvariantCulture);

                return true;
            }

            newValue = default!;

            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"exception: {ex.Message}");
            newValue = default!;

            return false;
        }
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Input, true),
            (Color.ToTextInputColorClass(), Color != TextInputColor.None),
            (TextAlignment.ToTextAlignmentClass(), TextAlignment != TextAlignment.None),
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

    [CascadingParameter]
    private EditContext EditContext { get; set; } = default!;

    /// <summary>
    /// Gets or sets a value indicating whether the minimum and maximum constraints are enabled.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets a value indicating whether the minimum and maximum constraints are enabled.")]
    [Parameter]
    public bool EnableMinMax { get; set; }

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
    /// Gets or sets the locale used for formatting and localization.
    /// <para>
    /// Default value is "en-US".
    /// </para>
    /// </summary>
    /// <remarks>
    /// This property determines the culture-specific settings for formatting, such as date, time,
    /// and number formats. Ensure the value is a valid BCP 47 language tag to avoid unexpected behavior.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue("en-US")]
    [Description("Gets or sets the locale used for formatting and localization.")]
    [Parameter]
    public string Locale { get; set; } = "en-US";

    /// <summary>
    /// Gets or sets the maximum allowable value.
    /// Max value is ignored if <see cref="EnableMinMax" /> is false.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the maximum allowable value. Max value is ignored if <code>EnableMinMax</code> is <b>false</b>.")]
    [ParameterTypeName("TValue")]
    [Parameter]
    public TValue Max { get; set; } = default!;

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
    /// Gets or sets the minimum allowable value.
    /// Min value is ignored if <see cref="EnableMinMax" /> is false.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the minimum allowable value. Min value is ignored if <code>EnableMinMax</code> is <b>false</b>.")]
    [ParameterTypeName("TValue")]
    [Parameter]
    public TValue Min { get; set; } = default!;

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
    /// Gets or sets the step interval for the parameter.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the step interval for the parameter.")]
    [ParameterTypeName("double?")]
    [Parameter]
    public double? Step { get; set; }

    /// <summary>
    /// Gets or sets the text alignment.
    /// <para>
    /// Default value is <see cref="TextAlignment.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(TextAlignment.None)]
    [Description("Gets or sets the text alignment.")]
    [Parameter]
    public TextAlignment TextAlignment { get; set; } = TextAlignment.None;

    /// <summary>
    /// Gets or sets the value.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the value.")]
    [ParameterTypeName("TValue")]
    [Parameter]
    public TValue Value { get; set; } = default!;

    /// <summary>
    /// This event fires when the <see cref="NumberInput<TValue>" /> value changes.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the <code>NumberInput<TValue></code> value changes.")]
    [ParameterTypeName("EventCallback<TValue>")]
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the expression.")]
    [ParameterTypeName("Expression<Func<string>>?")]
    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; } = default!;

    #endregion
}
