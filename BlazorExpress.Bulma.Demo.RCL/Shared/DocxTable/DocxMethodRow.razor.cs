namespace BlazorExpress.Bulma.Demo.RCL;

public partial class DocxMethodRow<TItem> : ComponentBase
{
    private string AddedVersion => MethodInfo.GetMethodAddedVersion();

    private string Description => MethodInfo.GetMethodDescription();

    public string ReturnType => MethodInfo.GetMethodReturnType();

    public string ReturnTypeShortName => ReturnType.Contains(".")
        ? ReturnType.Split('.').Last()
        : ReturnType;

    [Parameter]
    public MethodInfo MethodInfo { get; set; } = default!;
}