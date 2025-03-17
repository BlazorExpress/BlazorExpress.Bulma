namespace BlazorExpress.Bulma;

public partial class GridDetailView<TItem> : BulmaComponentBase
{
    #region Fields and Constants

    private RenderFragment<TItem>? gridDetailViewTemplate;

    #endregion

    #region Methods

    protected override async Task OnInitializedAsync()
    {
        Id = IdUtility.GetNextId(); // Required

        if (Parent is not null)
            Parent.SetGridDetailView(this);

        await base.OnInitializedAsync();
    }

    #endregion

    #region Properties, Indexers

    /// <summary>
    /// Gets or sets the child content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment<TItem> ChildContent { get; set; } = default!;

    internal RenderFragment<TItem> GetTemplate => gridDetailViewTemplate ??= rowData => builder => { builder.AddContent(100, ChildContent, rowData); };

    [CascadingParameter] public Grid<TItem> Parent { get; set; } = default!;

    #endregion
}
