namespace BlazorExpress.Bulma;

/// <summary>
/// Block component
/// <see href="https://bulma.io/documentation/elements/block/" />
/// </summary>
public partial class Block : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames => CssUtility.BuildClassNames(Class, (BulmaCssClass.Block, true));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the child content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion

    [AddedVersion("1.0.0")]
    [Description("Test 1 method")]
    public void Test1() { }

    [AddedVersion("1.0.0")]
    [Description("Test 2 method")]
    public int Test2(int a, int b) => a + b;
}
