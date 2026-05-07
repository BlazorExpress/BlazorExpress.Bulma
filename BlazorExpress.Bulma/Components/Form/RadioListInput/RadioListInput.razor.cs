namespace BlazorExpress.Bulma;

/// <summary>
/// RadioListInput component
/// <para>
///     <see href="https://bulma.io/documentation/form/radio/#list-of-radio-buttons" />
/// </para>
/// </summary>
public partial class RadioListInput<TValue> : BulmaComponentBase
{
    #region Fields and Constants

    private readonly IEqualityComparer<TValue> comparer = EqualityComparer<TValue>.Default;

    private readonly string generatedName = $"be-radio-list-input-{Guid.NewGuid():N}";

    private FieldIdentifier fieldIdentifier = default!;

    private List<RadioListInputItem<TValue>> items = new();

    #endregion

    #region Methods

    protected override void OnInitialized()
    {
        AdditionalAttributes ??= new Dictionary<string, object>();

        base.OnInitialized();
    }

    protected override void OnParametersSet()
    {
        items = Items?.ToList() ?? new List<RadioListInputItem<TValue>>();

        if (ValueExpression is not null)
            fieldIdentifier = FieldIdentifier.Create(ValueExpression);
    }

    /// <summary>
    /// Disables the <see cref="RadioListInput{TValue}" />.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Disables the <code>RadioListInput&lt;TValue&gt;</code>.")]
    public void Disable() => Disabled = true;

    /// <summary>
    /// Enables the <see cref="RadioListInput{TValue}" />.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Enables the <code>RadioListInput&lt;TValue&gt;</code>.")]
    public void Enable() => Disabled = false;

    private string? GetInputId(int index) =>
        string.IsNullOrWhiteSpace(Id)
            ? null
            : $"{Id}-{index}";

    private string? GetItemClassNames(RadioListInputItem<TValue> item) =>
        BuildClassNames(
            item.CssClass,
            (BulmaCssClass.Radio, true),
            (FieldCssClasses, !string.IsNullOrWhiteSpace(FieldCssClasses))
        );

    private string? GetItemStyleNames(RadioListInputItem<TValue> item) =>
        BuildStyleNames(
            item.Style
        );

    private bool IsChecked(TValue value) => comparer.Equals(Value, value);

    private bool IsItemDisabled(RadioListInputItem<TValue> item) => Disabled || item.Disabled;

    private async Task OnChangeAsync(RadioListInputItem<TValue> item)
    {
        if (IsItemDisabled(item))
            return;

        if (ValueChanged.HasDelegate)
            await ValueChanged.InvokeAsync(item.Value);
        else
            Value = item.Value;

        if (ValueExpression is not null)
            EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Radios, true)
        );

    /// <summary>
    /// Gets or sets the disabled state for the entire radio list.
    /// <para>
    /// Default value is false.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the disabled state for the entire radio list.")]
    [Parameter]
    public bool Disabled { get; set; }

    [CascadingParameter]
    private EditContext EditContext { get; set; } = default!;

    private string FieldCssClasses =>
        ValueExpression is not null
            ? EditContext?.FieldCssClass(fieldIdentifier) ?? string.Empty
            : string.Empty;

    private string InputName =>
        string.IsNullOrWhiteSpace(Name)
            ? generatedName
            : Name;

    /// <summary>
    /// Gets or sets the radio items rendered by the component.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the radio items rendered by the component.")]
    [ParameterTypeName("IEnumerable<RadioListInputItem<TValue>>?")]
    [EditorRequired]
    [Parameter]
    public IEnumerable<RadioListInputItem<TValue>>? Items { get; set; }

    /// <summary>
    /// Gets or sets the content template used for each radio item.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the content template used for each radio item.")]
    [ParameterTypeName("RenderFragment<RadioListInputItem<TValue>>?")]
    [Parameter]
    public RenderFragment<RadioListInputItem<TValue>>? ItemTemplate { get; set; }

    /// <summary>
    /// Gets or sets the radio group name shared by each rendered input.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the radio group name shared by each rendered input.")]
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the selected value.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the selected value.")]
    [ParameterTypeName("TValue")]
    [Parameter]
    public TValue Value { get; set; } = default!;

    /// <summary>
    /// This event fires when the <see cref="RadioListInput{TValue}" /> value changes.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("This event fires when the <code>RadioListInput&lt;TValue&gt;</code> value changes.")]
    [ParameterTypeName("EventCallback<TValue>")]
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the expression.")]
    [ParameterTypeName("Expression<Func<TValue>>?")]
    [Parameter]
    public Expression<Func<TValue>>? ValueExpression { get; set; } = default!;

    #endregion
}
