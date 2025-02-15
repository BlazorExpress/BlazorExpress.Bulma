namespace BlazorExpress.Bulma;

/// <summary>
/// Attribute to specify the parameter type name.
/// </summary>
public class ParameterTypeNameAttribute : Attribute
{
    public string TypeName { get; }

    public ParameterTypeNameAttribute(string typeName)
    {
        TypeName = typeName;
    }
}