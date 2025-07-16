namespace BlazorExpress.Bulma.Docx;

public partial class DocxEventCallbackRow<TItem> : BulmaComponentBase
{
    private string AddedVersion => PropertyInfo.GetPropertyAddedVersion();

    private string Description => PropertyInfo.GetPropertyDescription();

    private string ParameterTypeName => PropertyInfo.GetParameterTypeName();

    private string ReturnType => ParameterTypeName ?? PropertyInfo.GetEventCallbackReturnType();

    [Parameter]
    public PropertyInfo PropertyInfo { get; set; } = default!;
}