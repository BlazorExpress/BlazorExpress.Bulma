namespace BlazorExpress.Bulma.Demo.RCL;

public partial class SectionHeading : ComponentBase
{
    #region Members

    private string? classNames => Size.ToTitleSizeClass();

    private string link => $"{PageUrl}#{HashTagName}".Trim().ToLower();

    #endregion

    #region Methods

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await Task.Delay(200);
        await JS.InvokeVoidAsync("navigateToHeading");
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task OnClick()
    {
        await JS.InvokeVoidAsync("navigateToHeading");
    }

    #endregion

    #region Properties

    [Parameter] public HeadingSize Size { get; set; }

    [Parameter] public string? Text { get; set; }

    [Parameter] public string? PageUrl { get; set; }

    [Parameter] public string? HashTagName { get; set; }

    [Inject] protected IJSRuntime JS { get; set; } = default!;

    #endregion
}