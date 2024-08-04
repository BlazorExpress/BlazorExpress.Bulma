namespace BlazorExpress.Bulma;

public sealed record class FilterItem
{
    #region Constructors

    public FilterItem(string propertyName, string value, FilterOperator @operator, StringComparison stringComparison)
    {
        PropertyName = propertyName;
        Value = value;
        Operator = @operator;
        StringComparison = stringComparison;
    }

    private FilterItem(Type propertType, string propertyName, string value, FilterOperator @operator, StringComparison stringComparison)
    {
        PropertType = propertType;
        PropertyName = propertyName;
        Value = value;
        Operator = @operator;
        StringComparison = stringComparison;
    }

    #endregion

    #region Properties, Indexers

    public FilterOperator Operator { get; private set; }

    public Type PropertType { get; private set; } = default!;
    public string PropertyName { get; private set; }
    public StringComparison StringComparison { get; private set; }
    public string Value { get; private set; }

    #endregion
}
