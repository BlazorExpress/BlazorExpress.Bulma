namespace BlazorExpress.Bulma;

public partial class GridDetailView<TItem> : BulmaComponentBase
{
    private RenderFragment<TItem>? gridDetailViewTemplate;

    protected override async Task OnInitializedAsync()
    {
        Id = IdUtility.GetNextId(); // Required

        if (Parent is not null)
            Parent.SetGridDetailView(this);

        await base.OnInitializedAsync();
    }

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment<TItem> ChildContent { get; set; } = default!;

    internal RenderFragment<TItem> GetTemplate =>
        gridDetailViewTemplate ??= rowData => builder =>
                                              {
                                                  builder.AddContent(100, ChildContent, rowData);
                                              };

    [CascadingParameter]
    public Grid<TItem> Parent { get; set; } = default!;
}
