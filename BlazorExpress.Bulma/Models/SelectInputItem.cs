namespace BlazorExpress.Bulma;

/// <summary>
/// Represents an item used by <see cref="SelectInput{TValue}" />.
/// </summary>
/// <typeparam name="TValue">The type of the option value.</typeparam>
public class SelectInputItem<TValue>
{
    #region Constructors

    public SelectInputItem()
    {
    }

    public SelectInputItem(TValue value, string text)
    {
        Value = value;
        Text = text;
    }

    #endregion

    #region Properties, Indexers

    /// <summary>
    /// Gets or sets the option text.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the option text.")]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the option value.
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the option value.")]
    public TValue Value { get; set; } = default!;

    #endregion
}
