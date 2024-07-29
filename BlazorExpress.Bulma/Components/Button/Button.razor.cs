namespace BlazorExpress.Bulma;

/// <summary>
/// <see href="https://bulma.io/documentation/elements/button/" />
/// </summary>
public partial class Button : BulmaComponentBase
{
    private string? buttonTypeString => Type.ToButtonTypeString();

    #region Methods

    protected override void OnParametersSet()
    {
        if (IsLightVersion && IsDarkVersion)
        {
            throw new InvalidOperationException($"{nameof(Button)} requires one of {nameof(IsLightVersion)} or {nameof(IsDarkVersion)}, but both were specified.");
        }

        base.OnParametersSet();
    }

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames 
        => CssUtility.BuildClassNames(
            Class, 
            (BulmaCssClass.Button, true),
            (Color.ToButtonColorClass(), true),
            (BulmaCssClass.IsLight, IsLightVersion),
            (BulmaCssClass.IsDark, IsDarkVersion),
            (Size.ToButtonSizeClass(), Size != ButtonSize.None),
            (BulmaCssClass.IsFullWidth, IsFullWidth),
            (BulmaCssClass.IsResponsive, IsResponsive),
            (BulmaCssClass.IsOutlined, IsOutlined),
            (BulmaCssClass.IsInverted, IsInverted),
            (BulmaCssClass.IsRounded, IsRounded),
            (BulmaCssClass.IsLoading, IsLoading),
            (BulmaCssClass.IsSkeleton, IsSkeleton));

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public ButtonColor Color { get; set; }

    [Parameter]
    public string? Href { get; set; }

    [Parameter]
    public bool IsDarkVersion { get; set; }

    [Parameter]
    public bool IsDisabled { get; set; }

    [Parameter]
    public bool IsFullWidth { get; set; }

    [Parameter]
    public bool IsInverted { get; set; }

    /// <summary>
    /// If true, the skeleton variant will be enabled.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="false" />.
    /// </remarks>
    [Parameter]
    public bool IsSkeleton { get; set; }

    [Parameter]
    public bool IsLightVersion { get; set; }

    [Parameter]
    public bool IsLoading { get; set; }

    [Parameter]
    public bool IsOutlined { get; set; }

    [Parameter]
    public bool IsRounded { get; set; }

    [Parameter]
    public bool IsResponsive { get; set; }

    [Parameter]
    public ButtonSize Size { get; set; }

    /// <summary>
    /// Gets or sets the button type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ButtonType.Button" />.
    /// </remarks>
    [Parameter]
    public ButtonType Type { get; set; } = ButtonType.Button;

    #endregion
}
