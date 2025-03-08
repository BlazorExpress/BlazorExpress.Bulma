namespace BlazorExpress.Bulma;

public partial class GridEmptyDataTemplate<TItem> : BulmaComponentBase
{
    private RenderFragment? template;

    protected override async Task OnInitializedAsync()
    {
        Id = IdUtility.GetNextId(); // Required

        if (Parent is not null)
            Parent.SetGridEmptyDataTemplate(this);

        await base.OnInitializedAsync();
    }

    /// <summary>
    /// Gets or sets the child content.
    /// <para>
    /// Default value is <see langword="null"/>.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    internal RenderFragment Template => template ??= builder => { builder.AddContent(100, ChildContent); };

    [CascadingParameter]
    public Grid<TItem> Parent { get; set; } = default!;
}
