namespace BlazorExpress.Bulma.Demo.RCL;

public partial class DocxPropertyRow<TItem> : ComponentBase
{
    private string AddedVersion => typeof(TItem).GetPropertyAddedVersion(PropertyName);
    
    private string DefaultValue => typeof(TItem).GetPropertyDefaultValue(PropertyName);
    
    private string Description => typeof(TItem).GetPropertyDescription(PropertyName);
    
    private string ParameterTypeName => typeof(TItem).GetParameterTypeName(PropertyName);

    private string PropertyTypeName => typeof(TItem).GetPropertyTypeName(PropertyName);

    private string PropertyTypeShortName => ParameterTypeName ?? (PropertyTypeName.Contains(".") 
        ? PropertyTypeName.Split('.').Last()
        : PropertyTypeName);

    private bool IsRequired => typeof(TItem).IsPropertyRequired(PropertyName);

    [Parameter]
    public string PropertyName { get; set; } = default!;
}