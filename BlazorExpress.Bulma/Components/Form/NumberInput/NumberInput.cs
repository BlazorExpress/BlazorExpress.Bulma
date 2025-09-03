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
        if (State == NumberInputState.Loading)
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
        builder.AddAttribute(208, "step", step);
        builder.AddAttribute(209, "disabled", Disabled);
        builder.AddAttribute(210, "placeholder", Placeholder);
        builder.AddAttribute(211, "maxlength", MaxLength);
        builder.AddAttribute(212, "autocomplete", AutoCompleteAsString);
        builder.AddMultipleAttributes(213, AdditionalAttributes);
        builder.AddAttribute(214, "onchange", OnChange);
        builder.AddElementReferenceCapture(215, __inputReference => Element = __inputReference);

        builder.CloseElement(); // close: input

        if (State == NumberInputState.Loading)
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

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync(NumberInputJsInterop.Initialize, Id, isFloatingNumber(), AllowNegativeNumbers, cultureInfo.NumberFormat.NumberDecimalSeparator);

            var currentValue = Value; // object

            if (currentValue is null || !TryParseValue(currentValue, out var value))
                Value = default!;
            else if (EnableMinMax && Min is not null && IsLeftGreaterThanRight(Min, Value)) // value < min
                Value = Min;
            else if (EnableMinMax && Max is not null && IsLeftGreaterThanRight(Value, Max)) // value > max
                Value = Max;
            else
                Value = value;

            await ValueChanged.InvokeAsync(Value);
        }

        await base.OnAfterRenderAsync(firstRender);
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

    private string GetInvariantNumber(TValue value)
    {
        if (value is null) return string.Empty;

        if (value is float floatValue) return floatValue.ToString(CultureInfo.InvariantCulture);

        if (value is double doubleValue) return doubleValue.ToString(CultureInfo.InvariantCulture);

        if (value is decimal decimalValue) return decimalValue.ToString(CultureInfo.InvariantCulture);

        // All numbers without decimal places work fine by default
        return value?.ToString() ?? string.Empty;
    }

    /// <summary>
    /// Determines whether the type <typeparamref name="TValue"/> represents a floating-point number type.
    /// </summary>
    /// <remarks>
    /// This method checks if <typeparamref name="TValue"/> is one of the following types: <see cref="float"/>, 
    /// <see cref="double"/>, <see cref="decimal"/>, or their nullable counterparts.
    /// </remarks>
    /// <returns><see langword="true"/> if <typeparamref name="TValue"/> is a floating-point number type; otherwise, <see langword="false"/>.
    /// </returns>
    private bool isFloatingNumber() =>
        typeof(TValue) == typeof(float)
        || typeof(TValue) == typeof(float?)
        || typeof(TValue) == typeof(double)
        || typeof(TValue) == typeof(double?)
        || typeof(TValue) == typeof(decimal)
        || typeof(TValue) == typeof(decimal?);

    /// <summary>
    /// Determines whether the specified <paramref name="left"/> value is greater than the specified <paramref
    /// name="right"/> value.
    /// </summary>
    /// <remarks>This method supports comparisons for various numeric types, including <see cref="sbyte"/>,
    /// <see cref="short"/>, <see cref="int"/>, <see cref="long"/>, <see cref="float"/>, <see cref="double"/>, and <see
    /// cref="decimal"/>, as well as their nullable counterparts. If the type of <typeparamref name="TValue"/> is not a
    /// supported numeric type, the method will always return <see langword="false"/>.</remarks>
    /// <param name="left">The left-hand operand to compare. Must be of a numeric type or a nullable numeric type.</param>
    /// <param name="right">The right-hand operand to compare. Must be of a numeric type or a nullable numeric type.</param>
    /// <returns><see langword="true"/> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <see
    /// langword="false"/>. For nullable numeric types, returns <see langword="false"/> if either <paramref
    /// name="left"/> or <paramref name="right"/> is <see langword="null"/>.</returns>
    private bool IsLeftGreaterThanRight(TValue left, TValue right)
    {
        // sbyte
        if (typeof(TValue) == typeof(sbyte))
        {
            var l = Convert.ToSByte(left);
            var r = Convert.ToSByte(right);

            return l > r;
        }

        // sbyte?
        if (typeof(TValue) == typeof(sbyte?))
        {
            var l = left as sbyte?;
            var r = right as sbyte?;

            return l.HasValue && r.HasValue && l > r;
        }

        // short / int16
        if (typeof(TValue) == typeof(short))
        {
            var l = Convert.ToInt16(left);
            var r = Convert.ToInt16(right);

            return l > r;
        }

        // short? / int16?
        if (typeof(TValue) == typeof(short?))
        {
            var l = left as short?;
            var r = right as short?;

            return l.HasValue && r.HasValue && l > r;
        }

        // int
        if (typeof(TValue) == typeof(int))
        {
            var l = Convert.ToInt32(left);
            var r = Convert.ToInt32(right);

            return l > r;
        }

        // int?
        if (typeof(TValue) == typeof(int?))
        {
            var l = left as int?;
            var r = right as int?;

            return l.HasValue && r.HasValue && l > r;
        }

        // long
        if (typeof(TValue) == typeof(long))
        {
            var l = Convert.ToInt64(left);
            var r = Convert.ToInt64(right);

            return l > r;
        }

        // long?
        if (typeof(TValue) == typeof(long?))
        {
            var l = left as long?;
            var r = right as long?;

            return l.HasValue && r.HasValue && l > r;
        }

        // float / single
        if (typeof(TValue) == typeof(float))
        {
            var l = Convert.ToSingle(left);
            var r = Convert.ToSingle(right);

            return l > r;
        }

        // float? / single?
        if (typeof(TValue) == typeof(float?))
        {
            var l = left as float?;
            var r = right as float?;

            return l.HasValue && r.HasValue && l > r;
        }

        // double
        if (typeof(TValue) == typeof(double))
        {
            var l = Convert.ToDouble(left);
            var r = Convert.ToDouble(right);

            return l > r;
        }

        // double?
        if (typeof(TValue) == typeof(double?))
        {
            var l = left as double?;
            var r = right as double?;

            return l.HasValue && r.HasValue && l > r;
        }

        // decimal
        if (typeof(TValue) == typeof(decimal))
        {
            var l = Convert.ToDecimal(left);
            var r = Convert.ToDecimal(right);

            return l > r;
        }

        // decimal?
        if (typeof(TValue) == typeof(decimal?))
        {
            var l = left as decimal?;
            var r = right as decimal?;

            return l.HasValue && r.HasValue && l > r;
        }

        return false;
    }

    private async Task OnChange(ChangeEventArgs e)
    {
        var oldValue = Value;
        var newValue = e.Value; // object

        if (newValue is null || !TryParseValue(newValue, out var value))
            Value = default!;
        else if (EnableMinMax && Min is not null && IsLeftGreaterThanRight(Min, value)) // value < min
            Value = Min;
        else if (EnableMinMax && Max is not null && IsLeftGreaterThanRight(value, Max)) // value > max
            Value = Max;
        else
            Value = value;

        if (oldValue!.Equals(Value))
            await JSRuntime.InvokeVoidAsync(NumberInputJsInterop.SetValue, Id, Value);

        await ValueChanged.InvokeAsync(Value);

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
            (Color.ToNumberInputColorClass(), Color != NumberInputColor.None),
            (TextAlignment.ToTextAlignmentClass(), TextAlignment != TextAlignment.None),
            (Size.ToNumberInputSizeClass(), Size != NumberInputSize.None),
            (BulmaCssClass.IsRounded, IsRounded),
            (State.ToNumberInputStateClass(), State != NumberInputState.None)
        );

    /// <summary>
    /// Gets or sets a value indicating whether negative numbers are allowed.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Gets or sets a value indicating whether negative numbers are allowed.")]
    [Parameter]
    public bool AllowNegativeNumbers { get; set; }

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
    /// Gets or sets the color.
    /// <para>
    /// Default value is <see cref="NumberInputColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(NumberInputColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter]
    public NumberInputColor Color { get; set; } = NumberInputColor.None;

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
    /// Default value is <see cref="NumberInputSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(NumberInputSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter]
    public NumberInputSize Size { get; set; } = NumberInputSize.None;

    /// <summary>
    /// Gets or sets the state.
    /// <para>
    /// Default value is <see cref="NumberInputState.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(NumberInputState.None)]
    [Description("Gets or sets the state.")]
    [Parameter]
    public NumberInputState State { get; set; } = NumberInputState.None;

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
