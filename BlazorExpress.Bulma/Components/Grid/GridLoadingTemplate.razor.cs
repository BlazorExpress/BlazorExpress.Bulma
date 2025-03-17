namespace BlazorExpress.Bulma;

public partial class GridLoadingTemplate<TItem> : BulmaComponentBase
{
    #region Fields and Constants

    private RenderFragment? template;

    #endregion

    #region Methods

    protected override async Task OnInitializedAsync()
    {
        Id = IdUtility.GetNextId(); // Required

        if (Parent is not null)
            Parent.SetGridLoadingTemplate(this);

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
    public RenderFragment ChildContent { get; set; } = default!;

    [CascadingParameter] public Grid<TItem> Parent { get; set; } = default!;

    internal RenderFragment Template => template ??= builder => { builder.AddContent(100, ChildContent); };

    #endregion
}
