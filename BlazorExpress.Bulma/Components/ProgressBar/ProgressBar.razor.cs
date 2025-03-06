namespace BlazorExpress.Bulma;

/// <summary>
/// Progress Bar
/// <see href="https://bulma.io/documentation/elements/progress/" />
/// </summary>
public partial class ProgressBar : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? ClassNames => 
        BuildClassNames(
            Class, 
            (BulmaCssClass.Progress, true),
            (Color.ToProgressBarColorClass(), true)
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
    /// Gets or sets the value.
    /// <para>
    /// Default value is <see langword="null"/>.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the value.")]
    [Parameter]
    public float? Value { get; set; }

    private string? ValueAsPercentageString => 
        Value.HasValue ? $"{Value.Value.ToString(CultureInfo.InvariantCulture)}%" : null;

    #endregion
}
