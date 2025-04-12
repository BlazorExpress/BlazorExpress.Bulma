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

    private List<EnumItem>? items;
    private FieldIdentifier fieldIdentifier = default!;

    #endregion

    #region Methods

    protected override void OnInitialized()
    {
        items = EnumUtility<TEnum>.GetEnumItems();

        AdditionalAttributes ??= new Dictionary<string, object>();

        fieldIdentifier = FieldIdentifier.Create(ValueExpression!);

        base.OnInitialized();
    }

    private string? ContainerClassNames =>
        BuildClassNames(
            ContainerCssClass,
            (BulmaCssClass.Select, true),
            (BulmaCssClass.IsFlexDirectionRow, true)
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

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Select, true),
            (Color.ToTextInputColorClass(), Color != TextInputColor.None),
            (Size.ToTextInputSizeClass(), Size != TextInputSize.None),
            (BulmaCssClass.IsRounded, IsRounded),
            (State.ToTextInputStateClass(), State != TextInputState.None)
        );

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
    /// This event fires when the <see cref="TextInput" /> value changes.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event fires when the <code>TextInput</code> value changes.")]
    [Parameter]
    public EventCallback<TEnum> ValueChanged { get; set; }

    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the expression.")]
    [ParameterTypeName("Expression<Func<string>>?")]
    [Parameter]
    public Expression<Func<TEnum>> ValueExpression { get; set; } = default!;

    #endregion
}
