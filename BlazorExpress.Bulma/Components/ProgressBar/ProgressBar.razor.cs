namespace BlazorExpress.Bulma;

/// <summary>
/// Progress Bar
/// <para>
///     <see href="https://bulma.io/documentation/elements/progress/" />
/// </para>
/// </summary>
public partial class ProgressBar : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Progress, true),
            (Color.ToProgressBarColorClass(), true),
            (Size.ToProgressBarSizeClass(), Size != ProgressBarSize.None)
        );

    /// <summary>
    /// Gets or sets the color.
    /// <para>
    /// Default value is <see cref="ProgressBarColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(ProgressBarColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter]
    public ProgressBarColor Color { get; set; } = ProgressBarColor.None;

    /// <summary>
    /// Gets or sets the maximum value.
    /// <para>
    /// Default value is 100.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(100)]
    [Description("Gets or sets the maximum value.")]
    [Parameter]
    public float Max { get; set; } = 100;

    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(ProgressBarSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter]
    public ProgressBarSize Size { get; set; } = ProgressBarSize.None;

    /// <summary>
    /// Gets or sets the value.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the value.")]
    [ParameterTypeName("float?")]
    [Parameter]
    public float? Value { get; set; }

    private string? ValueAsPercentageString => Value.HasValue ? $"{Value.Value.ToString(CultureInfo.InvariantCulture)}%" : null;

    #endregion
}
