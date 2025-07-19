namespace BlazorExpress.Bulma.Docx;

public partial class DocxTable<TItem> : ComponentBase
{
    [Parameter]
    public DocType DocType { get; set; } = DocType.Parameters;
}
