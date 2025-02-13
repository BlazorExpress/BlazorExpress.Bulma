namespace BlazorExpress.Bulma.Demo.RCL;

public partial class DocxMethodRow<TItem> : ComponentBase
{
    private string AddedVersion => typeof(TItem).GetMethodAddedVersion(MethodName);

    private string Description => typeof(TItem).GetMethodDescription(MethodName);

    public string ReturnType => typeof(TItem).GetMethodReturnType(MethodName);
    public string ReturnTypeShortName => ReturnType.Contains(".")
        ? ReturnType.Split('.').Last()
        : ReturnType;

    [Parameter]
    public string MethodName { get; set; } = default!;
}