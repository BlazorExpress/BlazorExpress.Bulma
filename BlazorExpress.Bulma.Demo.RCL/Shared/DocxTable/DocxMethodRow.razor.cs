namespace BlazorExpress.Bulma.Demo.RCL;

public partial class DocxMethodRow<TItem> : ComponentBase
{
    private string AddedVersion => typeof(TItem).GetPropertyAddedVersion(MethodName);

    private string Description => typeof(TItem).GetPropertyDescription(MethodName);

    [Parameter]
    public string MethodName { get; set; } = default!;

    [Parameter]
    public string ReturnType { get; set; } = default!;
}