namespace BlazorExpress.Bulma;

/// <summary>
/// SelectInput component
/// <para>
///     <see href="https://bulma.io/documentation/form/select/" />
/// </para>
/// </summary>
public partial class SelectInput<TValue> : BulmaComponentBase
{
    #region Fields and Constants

    private FieldIdentifier fieldIdentifier = default!;

    private List<SelectInputItem<TValue>> items = new();

    #endregion

    #region Methods

    protected override void OnInitialized()
    {
        AdditionalAttributes ??= new Dictionary<string, object>();

        base.OnInitialized();
    }

    protected override void OnParametersSet()
    {
        items = Items?.ToList() ?? new List<SelectInputItem<TValue>>();

        if (TextExpression is not null)
            fieldIdentifier = FieldIdentifier.Create(TextExpression);

        if (ValueExpression is not null)
            fieldIdentifier = FieldIdentifier.Create(ValueExpression);
    }

    /// <summary>
    /// Disables the <see cref="SelectInput{TValue}" />.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Disables the <code>SelectInput&lt;TValue&gt;</code>.")]
    public void Disable() => Disabled = true;

    /// <summary>
    /// Enables the <see cref="SelectInput{TValue}" />.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Enables the <code>SelectInput&lt;TValue&gt;</code>.")]
    public void Enable() => Disabled = false;

    private async Task OnChange(ChangeEventArgs e)
    {
        var nextValue = default(TValue);
        var nextText = string.Empty;

        if (e.Value is string selectedIndex
            && int.TryParse(selectedIndex, NumberStyles.Integer, CultureInfo.InvariantCulture, out var index)
            && index >= 0
            && index < items.Count)
        {
            var item = items[index];
            nextValue = item.Value;
            nextText = item.Text;
        }

        if (ValueChanged.HasDelegate)
            await ValueChanged.InvokeAsync(nextValue!);
        else
            Value = nextValue!;

        if (TextChanged.HasDelegate)
            await TextChanged.InvokeAsync(nextText);
        else
            Text = nextText;

        EditContext?.NotifyFieldChanged(fieldIdentifier);
    }

    private int GetSelectedIndex()
    {
        for (int index = 0; index < items.Count; index++)
        {
            if (EqualityComparer<TValue>.Default.Equals(items[index].Value, Value))
                return index;
        }

        if (!string.IsNullOrWhiteSpace(Text))
        {
            for (int index = 0; index < items.Count; index++)
            {
                if (string.Equals(items[index].Text, Text, StringComparison.Ordinal))
                    return index;
            }
        }

        return -1;
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class
        );

    private string? ControlClassNames =>
        BuildClassNames(
            ContainerCssClass,
            (BulmaCssClass.Control, true),
            (BulmaCssClass.HasIconsLeft, LeftIcon is not null),
            (BulmaCssClass.HasIconsRight, RightIcon is not null)
        );

    /// <summary>
    /// Gets or sets the color.
    /// <para>
    /// Default value is <see cref="SelectInputColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(SelectInputColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter]
    public SelectInputColor Color { get; set; } = SelectInputColor.None;

    /// <summary>
    /// Gets or sets the CSS class for the container element.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS class for the container element.")]
    [Parameter]
    public string? ContainerCssClass { get; set; }

    /// <summary>
    /// Gets or sets the CSS style for the container element.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS style for the container element.")]
    [Parameter]
    public string? ContainerCssStyle { get; set; }

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

    private string FieldCssClasses => EditContext?.FieldCssClass(fieldIdentifier) ?? string.Empty;

    /// <summary>
    /// Gets or sets the items rendered by the select element.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the items rendered by the select element.")]
    [ParameterTypeName("IEnumerable<SelectInputItem<TValue>>?")]
    [EditorRequired]
    [Parameter]
    public IEnumerable<SelectInputItem<TValue>>? Items { get; set; }

    /// <summary>
    /// If true, the rounded variant will be enabled.
    /// <para>
    /// The default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("If true, the rounded variant will be enabled.")]
    [Parameter]
    public bool IsRounded { get; set; }

    /// <summary>
    /// Gets or sets the content displayed after the select element on the left side.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the content displayed after the select element on the left side.")]
    [Parameter]
    public RenderFragment? LeftIcon { get; set; }

    /// <summary>
    /// Gets or sets the placeholder option text.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the placeholder option text.")]
    [Parameter]
    public string? Placeholder { get; set; }

    /// <summary>
    /// Gets or sets the content displayed after the select element on the right side.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the content displayed after the select element on the right side.")]
    [Parameter]
    public RenderFragment? RightIcon { get; set; }

    private string? SelectedOptionKey
    {
        get
        {
            var selectedIndex = GetSelectedIndex();

            if (selectedIndex >= 0)
                return selectedIndex.ToString(CultureInfo.InvariantCulture);

            return string.IsNullOrWhiteSpace(Placeholder)
                    ? null
                    : string.Empty;
        }
    }

    private string? SelectContainerClassNames =>
        BuildClassNames(
            null,
            (BulmaCssClass.Select, true),
            (Color.ToSelectInputColorClass(), Color != SelectInputColor.None),
            (Size.ToSelectInputSizeClass(), Size != SelectInputSize.None),
            (BulmaCssClass.IsRounded, IsRounded),
            (State.ToSelectInputStateClass(), State != SelectInputState.None)
        );

    /// <summary>
    /// Gets or sets the size.
    /// <para>
    /// Default value is <see cref="SelectInputSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(SelectInputSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter]
    public SelectInputSize Size { get; set; } = SelectInputSize.None;

    /// <summary>
    /// Gets or sets the state.
    /// <para>
    /// Default value is <see cref="SelectInputState.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(SelectInputState.None)]
    [Description("Gets or sets the state.")]
    [Parameter]
    public SelectInputState State { get; set; } = SelectInputState.None;

    /// <summary>
    /// Gets or sets the selected item text.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the selected item text.")]
    [Parameter]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// This event fires when the <see cref="SelectInput{TValue}" /> text changes.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("This event fires when the <code>SelectInput&lt;TValue&gt;</code> text changes.")]
    [Parameter]
    public EventCallback<string> TextChanged { get; set; }

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the expression.")]
    [ParameterTypeName("Expression<Func<string>>?")]
    [Parameter]
    public Expression<Func<string>>? TextExpression { get; set; } = default!;

    /// <summary>
    /// Gets or sets the selected item value.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the selected item value.")]
    [ParameterTypeName("TValue")]
    [Parameter]
    public TValue Value { get; set; } = default!;

    /// <summary>
    /// This event fires when the <see cref="SelectInput{TValue}" /> value changes.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("This event fires when the <code>SelectInput&lt;TValue&gt;</code> value changes.")]
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
