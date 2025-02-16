namespace BlazorExpress.Bulma.Demo.RCL;

public partial class DocxEventCallbackRow<TItem> : ComponentBase
{
    private string AddedVersion => PropertyInfo.GetPropertyAddedVersion();

    private string Description => PropertyInfo.GetPropertyDescription();

    private string ReturnType => PropertyInfo.GetEventCallbackReturnType();

    [Parameter]
    public PropertyInfo PropertyInfo { get; set; } = default!;
}