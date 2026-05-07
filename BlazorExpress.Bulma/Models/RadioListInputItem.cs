namespace BlazorExpress.Bulma;

/// <summary>
/// Represents an item used by <see cref="RadioListInput{TValue}" />.
/// </summary>
/// <typeparam name="TValue">The type of the radio value.</typeparam>
public class RadioListInputItem<TValue>
{
    #region Constructors

    public RadioListInputItem()
    {
    }

    public RadioListInputItem(TValue value, string text)
    {
        Value = value;
        Text = text;
    }

    #endregion

    #region Properties, Indexers

    /// <summary>
    /// Gets or sets the CSS class applied to the item label.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS class applied to the item label.")]
    public string? CssClass { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the item is disabled.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("Gets or sets a value indicating whether the item is disabled.")]
    public bool Disabled { get; set; }

    /// <summary>
    /// Gets or sets the CSS style applied to the item label.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the CSS style applied to the item label.")]
    public string? Style { get; set; }

    /// <summary>
    /// Gets or sets the item text.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the item text.")]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the item value.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the item value.")]
    public TValue Value { get; set; } = default!;

    #endregion
}
