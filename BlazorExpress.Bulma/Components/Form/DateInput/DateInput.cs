﻿namespace BlazorExpress.Bulma;

/// <summary>
/// DateInput component
/// <para>
///     <see href="https://bulma.io/documentation/form/input/" />
/// </para>
/// </summary>
public class DateInput<TValue> : BulmaComponentBase
{
    #region Fields and Constants

    /// <summary>
    /// Default date format is `yyyy-MM-dd`.
    /// </summary>
    private readonly string defaultFormat = "yyyy-MM-dd";

    private FieldIdentifier fieldIdentifier = default!;

    private string? maxAsString;

    private string? minAsString;

    private string? valueAsString;

    private TValue oldMax = default!;

    private TValue oldMin = default!;

    private TValue? oldValue;

    private bool resetValue;

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
        if (EnableMaxMin)
        {
            builder.AddAttributeIfNotNullOrWhiteSpace(205, "max", maxAsString);
            builder.AddAttributeIfNotNullOrWhiteSpace(206, "min", minAsString);
        }
        builder.AddAttribute(207, "value", valueAsString);
        builder.AddAttribute(208, "disabled", Disabled);
        builder.AddAttribute(209, "autocomplete", AutoCompleteAsString);
        builder.AddAttribute(210, "step", Step);
        builder.AddMultipleAttributes(211, AdditionalAttributes);
        builder.AddAttribute(212, "onchange", OnChange);
        builder.AddElementReferenceCapture(213, __inputReference => Element = __inputReference);

        builder.CloseElement(); // close: input

        if (State == TextInputState.Loading)
            builder.CloseElement(); // close: div
    }

    protected override void OnInitialized()
    {
        if (!(typeof(TValue) == typeof(DateOnly)
              || typeof(TValue) == typeof(DateOnly?)
              || typeof(TValue) == typeof(DateTime)
              || typeof(TValue) == typeof(DateTime?)
             ))
            throw new InvalidOperationException($"{typeof(TValue)} is not supported.");

        oldMax = Max;
        oldMin = Min;
        oldValue = Value;

        if (EnableMaxMin && IsLeftGreaterThan(Min, Max))
            throw new InvalidOperationException("Min parameter must be less than or equal to Max parameter.");

        if (EnableMaxMin)
        {
            maxAsString = GetDefaultFormattedValueAsString(Max);
            minAsString = GetDefaultFormattedValueAsString(Min);
        }

        valueAsString = GetDefaultFormattedValueAsString(Value);

        AdditionalAttributes ??= new Dictionary<string, object>();

        fieldIdentifier = FieldIdentifier.Create(ValueExpression!);

        base.OnInitialized();
    }

    protected override void OnParametersSet()
    {
        if (!IsFirstRenderComplete)
            return;

        if (!oldMax!.Equals(Max))
        {
            oldMax = Max;
            if (EnableMaxMin)
                maxAsString = GetDefaultFormattedValueAsString(Max);
        }

        if (!oldMin!.Equals(Min))
        {
            oldMin = Min;
            if (EnableMaxMin)
                minAsString = GetDefaultFormattedValueAsString(Min);
        }

        if (!oldValue!.Equals(Value))
        {
            oldValue = Value;
            valueAsString = GetDefaultFormattedValueAsString(Value);
        }

        if (resetValue)
        {
            resetValue = false;
            valueAsString = null;
            queuedTasks.Enqueue(async () =>
            {
                valueAsString = GetDefaultFormattedValueAsString(Value);
                await InvokeAsync(StateHasChanged);
            });
        }
    }

    /// <summary>
    /// Disables the <see cref="TextInput" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Disables the <code>DateInput</code>.")]
    public void Disable() => Disabled = true;

    /// <summary>
    /// Enables the <see cref="TextInput" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Enables the <code>DateInput</code>.")]
    public void Enable() => Disabled = false;

    private string? GetDefaultFormattedValueAsString(TValue value)
    {
        if (value == null)
            return null;

        return value switch
        {
            DateOnly dateOnly => dateOnly.ToString(defaultFormat, CultureInfo.CurrentCulture),
            DateTime dateTime => dateTime.ToString(defaultFormat, CultureInfo.CurrentCulture),
            _ => throw new InvalidOperationException($"{typeof(TValue)} is not supported.")
        };
    }

    private bool IsLeftGreaterThan(TValue left, TValue right)
    {
        if (left is null || right is null)
            return false;

        return left switch
        {
            DateOnly dateOnly => dateOnly > (DateOnly)(object)right,
            DateTime dateTime => dateTime > (DateTime)(object)right,
            _ => throw new InvalidOperationException($"{typeof(TValue)} is not supported.")
        };
    }

    private async Task OnChange(ChangeEventArgs e)
    {
        if (e.Value is string _value)
        {
            TValue newValue = default!;

            if (_value != string.Empty)
                newValue = TryParseValue(_value, out var value) ? value : default!;
            else if (EnableMaxMin && Value!.Equals(Min)) // Scenario: incorrect date value is entered second time from the UI
            {
                resetValue = true;
                newValue = Min;
            }
            else if (EnableMaxMin) // Scenario: incorrect date value is entered or cleared from UI
                newValue = Min;

            if (EnableMaxMin)
            {
                if (IsLeftGreaterThan(newValue, Max)) // newValue > Max || Max < newValue
                {
                    resetValue = true; // in browser, when user selects a date greater than Max by using keybord cursor keys
                    newValue = Max;
                }
                if (IsLeftGreaterThan(Min, newValue)) // Min > newValue || newValue < Min
                {
                    resetValue = true; // in browser, when user selects a date less than Min by using keybord cursor keys
                    newValue = Min;
                }
            }

            if (ValueChanged.HasDelegate)
                await ValueChanged.InvokeAsync(newValue);
            else
                Value = newValue;

            EditContext?.NotifyFieldChanged(fieldIdentifier);
        }
    }

    private bool TryParseValue(object value, out TValue newValue)
    {
        try
        {
            // DateOnly / DateOnly?
            if (typeof(TValue) == typeof(DateOnly) || typeof(TValue) == typeof(DateOnly?))
            {
                if (DateTime.TryParse(value.ToString(), CultureInfo.CurrentCulture, DateTimeStyles.None, out var dt))
                {
                    newValue = (TValue)(object)DateOnly.FromDateTime(dt);

                    return true;
                }

                newValue = default!;

                return false;
            }
            // DateTime / DateTime?
            else if (typeof(TValue) == typeof(DateTime) || typeof(TValue) == typeof(DateTime?))
            {
                newValue = (TValue)Convert.ChangeType(value, typeof(DateTime), CultureInfo.CurrentCulture);

                return true;
            }

            newValue = default!;

            return false;
        }
        catch
        {
            Console.WriteLine($"DateInput.TryParseValue() => value: {value}, typeof(TValue): {typeof(TValue)}");
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
            (Size.ToDateInputSizeClass(), Size != DateInputSize.None),
            (BulmaCssClass.IsRounded, IsRounded),
            (State.ToTextInputStateClass(), State != TextInputState.None)
        );

    /// <summary>
    /// If <see langword="true" />, DateInput can complete the values automatically by the browser.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, <code>DateInput</code> can complete the values automatically by the browser.")]
    [Parameter]
    public bool AutoComplete { get; set; } = false;

    private string AutoCompleteAsString => AutoComplete ? "true" : "false";

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
    /// If <see langword="true" />, the <see cref="Max" /> and <see cref="Min" /> values will be used to restrict the date range.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, the <code>Max</code> and <code>Min</code> values will be used to restrict the date range.")]
    [Parameter]
    public bool EnableMaxMin { get; set; } = false;

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
    /// Gets or sets the max value. 
    /// If <see cref="EnableMaxMin" /> is <see langword="true" />, this value will be used.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the max value. If <code>EnableMaxMin</code> is <b>true</b>, this value will be used.")]
    [ParameterTypeName("TValue")]
    [Parameter]
    public TValue Max { get; set; } = default!;

    /// <summary>
    /// Gets or sets the min value.
    /// If <see cref="EnableMaxMin" /> is <see langword="true" />, this value will be used.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the min value. If <code>EnableMaxMin</code> is <b>true</b>, this value will be used.")]
    [ParameterTypeName("TValue")]
    [Parameter]
    public TValue Min { get; set; } = default!;

    /// <summary>
    /// Gets or sets the size.
    /// <para>
    /// Default value is <see cref="DateInputSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(DateInputSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter]
    public DateInputSize Size { get; set; } = DateInputSize.None;

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
    /// Gets or sets the step.
    /// <para>
    /// For date inputs, the value of step is given in days; and is treated as a number of milliseconds equal to 86,400,000 times the step value (the underlying numeric value is in milliseconds). 
    /// The default value of step is 1, indicating 1 day.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(1)]
    [Description("Gets or sets the step.")]
    [Parameter]
    public int Step { get; set; } = 1;

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
    /// This event fires when the <see cref="TextInput" /> value changes.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the <code>DateInput</code> value changes.")]
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
