namespace BlazorExpress.Bulma.Docx;

public partial class PageHero : BulmaComponentBase
{
    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public RenderFragment? TitleTemplate { get; set; }

    [Parameter]
    public string? SubTitle { get; set; }

    [Parameter]
    public RenderFragment? SubTitleTemplate { get; set; }
}
