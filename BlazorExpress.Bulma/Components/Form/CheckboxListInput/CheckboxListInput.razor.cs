namespace BlazorExpress.Bulma;

/// <summary>
/// CheckboxListInput component
/// <para>
///     <see href="https://bulma.io/documentation/form/checkbox/#list-of-checkboxes" />
/// </para>
/// </summary>
public partial class CheckboxListInput<TValue> : BulmaComponentBase
{
    #region Fields and Constants

    private readonly IEqualityComparer<TValue> comparer = EqualityComparer<TValue>.Default;

    private FieldIdentifier fieldIdentifier = default!;

    private List<CheckboxListInputItem<TValue>> items = new();

    private HashSet<TValue> selectedValues = new();

    #endregion

    #region Methods

    protected override void OnInitialized()
    {
        AdditionalAttributes ??= new Dictionary<string, object>();

        base.OnInitialized();
    }

    protected override void OnParametersSet()
    {
        items = Items?.ToList() ?? new List<CheckboxListInputItem<TValue>>();
        selectedValues = Values?.ToHashSet(comparer) ?? new HashSet<TValue>(comparer);

        if (ValuesExpression is not null)
            fieldIdentifier = FieldIdentifier.Create(ValuesExpression);
    }

    /// <summary>
    /// Clears all selected values.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Clears all selected values.")]
    public Task ClearAsync() => UpdateValuesAsync(new HashSet<TValue>(comparer));

    /// <summary>
    /// Disables the <see cref="CheckboxListInput{TValue}" />.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Disables the <code>CheckboxListInput&lt;TValue&gt;</code>.")]
    public void Disable() => Disabled = true;

    /// <summary>
    /// Enables the <see cref="CheckboxListInput{TValue}" />.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Enables the <code>CheckboxListInput&lt;TValue&gt;</code>.")]
    public void Enable() => Disabled = false;

    private string? GetInputId(int index) =>
        string.IsNullOrWhiteSpace(Id)
            ? null
            : $"{Id}-{index}";

    private string? GetItemClassNames(CheckboxListInputItem<TValue> item) =>
        BuildClassNames(
            item.CssClass,
            (BulmaCssClass.Checkbox, true)
        );

    private string? GetItemStyleNames(CheckboxListInputItem<TValue> item) =>
        BuildStyleNames(
            item.Style
        );

    private bool IsChecked(TValue value) => selectedValues.Contains(value);

    private bool IsItemDisabled(CheckboxListInputItem<TValue> item) => Disabled || item.Disabled;

    private async Task OnChangeAsync(CheckboxListInputItem<TValue> item, ChangeEventArgs e)
    {
        if (!BindConverter.TryConvertToBool(e.Value, CultureInfo.InvariantCulture, out var isChecked))
            return;

        var nextValues = Values?.ToHashSet(comparer) ?? new HashSet<TValue>(comparer);

        if (isChecked)
            nextValues.Add(item.Value);
        else
            nextValues.Remove(item.Value);

        await UpdateValuesAsync(nextValues);
    }

    /// <summary>
    /// Selects all enabled checkbox items.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Selects all enabled checkbox items.")]
    public Task SelectAllAsync()
    {
        var nextValues = new HashSet<TValue>(comparer);

        foreach (var item in items)
        {
            if (!IsItemDisabled(item))
                nextValues.Add(item.Value);
        }

        return UpdateValuesAsync(nextValues);
    }

    private async Task UpdateValuesAsync(HashSet<TValue> nextSelection)
    {
        var nextValues = new List<TValue>();

        foreach (var item in items)
        {
            if (nextSelection.Contains(item.Value))
                nextValues.Add(item.Value);
        }

        if (ValuesChanged.HasDelegate)
            await ValuesChanged.InvokeAsync(nextValues);
        else
            Values = nextValues;

        if (ValuesExpression is not null)
            EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Checkboxes, true),
            (BulmaCssClass.IsFlex, true),
            (BulmaCssClass.IsFlexWrapWrap, Orientation == CheckboxListInputOrientation.Horizontal),
            (GetOrientationClassName(), true),
            (Size.ToCheckboxListInputSizeClass(), Size != CheckboxListInputSize.None)
        );

    /// <summary>
    /// Gets or sets the disabled state for the entire checkbox list.
    /// <para>
    /// Default value is false.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("Gets or sets the disabled state for the entire checkbox list.")]
    [Parameter]
    public bool Disabled { get; set; }

    [CascadingParameter]
    private EditContext EditContext { get; set; } = default!;

    private string FieldCssClasses =>
        ValuesExpression is not null
            ? EditContext?.FieldCssClass(fieldIdentifier) ?? string.Empty
            : string.Empty;

    private string GetOrientationClassName() =>
        Orientation switch
        {
            CheckboxListInputOrientation.Vertical => BulmaCssClass.IsFlexDirectionColumn,
            _ => BulmaCssClass.IsFlexDirectionRow
        };

    /// <summary>
    /// Gets or sets the checkbox items rendered by the component.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the checkbox items rendered by the component.")]
    [ParameterTypeName("IEnumerable<CheckboxListInputItem<TValue>>?")]
    [EditorRequired]
    [Parameter]
    public IEnumerable<CheckboxListInputItem<TValue>>? Items { get; set; }

    /// <summary>
    /// Gets or sets the content template used for each checkbox item.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the content template used for each checkbox item.")]
    [ParameterTypeName("RenderFragment<CheckboxListInputItem<TValue>>?")]
    [Parameter]
    public RenderFragment<CheckboxListInputItem<TValue>>? ItemTemplate { get; set; }

    /// <summary>
    /// Gets or sets the checkbox input name shared by each rendered input.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the checkbox input name shared by each rendered input.")]
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the orientation.
    /// <para>
    /// Default value is <see cref="CheckboxListInputOrientation.Horizontal" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(CheckboxListInputOrientation.Horizontal)]
    [Description("Gets or sets the orientation.")]
    [Parameter]
    public CheckboxListInputOrientation Orientation { get; set; } = CheckboxListInputOrientation.Horizontal;

    /// <summary>
    /// Gets or sets the size.
    /// <para>
    /// Default value is <see cref="CheckboxListInputSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(CheckboxListInputSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter]
    public CheckboxListInputSize Size { get; set; } = CheckboxListInputSize.None;

    /// <summary>
    /// Gets or sets the selected values.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the selected values.")]
    [ParameterTypeName("List<TValue>?")]
    [Parameter]
    public List<TValue>? Values { get; set; }

    /// <summary>
    /// This event fires when the <see cref="CheckboxListInput{TValue}" /> values change.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("This event fires when the <code>CheckboxListInput&lt;TValue&gt;</code> values change.")]
    [ParameterTypeName("EventCallback<List<TValue>>")]
    [Parameter]
    public EventCallback<List<TValue>> ValuesChanged { get; set; }

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the expression.")]
    [ParameterTypeName("Expression<Func<List<TValue>?>>?")]
    [Parameter]
    public Expression<Func<List<TValue>?>>? ValuesExpression { get; set; } = default!;

    #endregion
}
