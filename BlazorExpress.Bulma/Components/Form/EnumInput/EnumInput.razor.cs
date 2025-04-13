namespace BlazorExpress.Bulma;

/// <summary>
/// EnumInput component
/// <para>
///     <see href="https://bulma.io/documentation/form/input/" />
/// </para>
/// </summary>
public partial class EnumInput<TEnum> : BulmaComponentBase where TEnum : Enum
{
    #region Fields and Constants

    private FieldIdentifier fieldIdentifier = default!;

    private List<EnumItem>? items;

    #endregion

    #region Methods

    protected override void OnInitialized()
    {
        items = EnumUtility<TEnum>.GetEnumItems();

        AdditionalAttributes ??= new Dictionary<string, object>();

        base.OnInitialized();
    }

    protected override void OnParametersSet()
    {
        if (TextExpression is not null)
            fieldIdentifier = FieldIdentifier.Create(TextExpression);

        if (ValueExpression is not null)
            fieldIdentifier = FieldIdentifier.Create(ValueExpression!);
    }

    /// <summary>
    /// Disables the <see cref="EnumInput" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Disables the <code>EnumInput</code>.")]
    public void Disable() => Disabled = true;

    /// <summary>
    /// Enables the <see cref="EnumInput" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("Enables the <code>EnumInput</code>.")]
    public void Enable() => Disabled = false;

    private void OnChange(ChangeEventArgs e)
    {
        if (e.Value is null)
        {
            Value = default!;
            return;
        }

        var newValue = int.TryParse(e.Value.ToString(), out int _value) ? _value : default!;

        // Value
        if (ValueChanged.HasDelegate)
            ValueChanged.InvokeAsync(newValue);
        else
            Value = newValue;

        // Text
        if (TextChanged.HasDelegate)
            TextChanged.InvokeAsync(items?.FirstOrDefault(i => i.Value == newValue)?.Text ?? string.Empty);
        else
            Text = items?.FirstOrDefault(i => i.Value == newValue)?.Text ?? string.Empty;
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Select, Color != EnumInputColor.None), // HACK: Bulma CSS class is not applied when color is set
            (Color.ToEnumInputColorClass(), Color != EnumInputColor.None)
        );

    /// <summary>
    /// Gets or sets the color.
    /// <para>
    /// Default value is <see cref="EnumInputColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(EnumInputColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter]
    public EnumInputColor Color { get; set; } = EnumInputColor.None;

    private string? ContainerClassNames =>
        BuildClassNames(
            ContainerCssClass,
            (BulmaCssClass.Select, true),
            (Size.ToEnumInputSizeClass(), Size != EnumInputSize.None),
            (BulmaCssClass.IsRounded, IsRounded),
            (State.ToEnumInputStateClass(), State != EnumInputState.None)
        );

    /// <summary>
    /// Gets or sets the CSS class for the container element.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
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
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS style for the container element.")]
    [Parameter]
    public string? ContainerCssStyle { get; set; }

    private string? ContainerStyleNames =>
        BuildClassNames(
            ContainerCssStyle
        );

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
    /// Gets or sets the size.
    /// <para>
    /// Default value is <see cref="EnumInputSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(EnumInputSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter]
    public EnumInputSize Size { get; set; } = EnumInputSize.None;

    /// <summary>
    /// Gets or sets the state.
    /// <para>
    /// Default value is <see cref="EnumInputState.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(EnumInputState.None)]
    [Description("Gets or sets the state.")]
    [Parameter]
    public EnumInputState State { get; set; } = EnumInputState.None;

    /// <summary>
    /// Gets or sets the text.
    /// <para>
    /// Default value is <see langword="null"/>.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the text.")]
    [Parameter]
    public string Text { get; set; } = default!;

    /// <summary>
    /// This event fires when the <see cref="EnumInput" /> text changes.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the <code>EnumInput</code> text changes.")]
    [Parameter]
    public EventCallback<string> TextChanged { get; set; }

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the expression.")]
    [ParameterTypeName("Expression<Func<string>>?")]
    [Parameter]
    public Expression<Func<string>> TextExpression { get; set; } = default!;

    /// <summary>
    /// Gets or sets the value.
    /// <para>
    /// Default value is 0.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(0)]
    [Description("Gets or sets the value.")]
    [Parameter]
    public int Value { get; set; }

    /// <summary>
    /// This event fires when the <see cref="EnumInput" /> value changes.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the <code>EnumInput</code> value changes.")]
    [Parameter]
    public EventCallback<int> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the expression.")]
    [ParameterTypeName("Expression<Func<int>>")]
    [Parameter]
    public Expression<Func<int>> ValueExpression { get; set; } = default!;

    #endregion
}
