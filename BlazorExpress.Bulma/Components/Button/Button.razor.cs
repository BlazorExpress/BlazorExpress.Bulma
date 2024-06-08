namespace BlazorExpress.Bulma;

/// <summary>
/// <see href="https://bulma.io/documentation/elements/button/" />
/// </summary>
public partial class Button : BulmaComponentBase
{
    #region Properties, Indexers

    protected override string? CssClassNames => CssUtility.BuildClassNames(Class, (BulmaCssClass.Box, true));

    /// <summary>
    /// Gets or sets the button type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ButtonType.Button" />.
    /// </remarks>
    [Parameter]
    public ButtonType Type { get; set; } = ButtonType.Button;

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    #endregion
}
