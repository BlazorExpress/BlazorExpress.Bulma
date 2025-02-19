namespace BlazorExpress.Bulma;

/// <summary>
/// Button component
/// <see href="https://bulma.io/documentation/elements/button/" />
/// </summary>
public partial class Button : BulmaComponentBase
{
    #region Methods

    protected override void OnParametersSet()
    {
        if (IsLightVersion && IsDarkVersion) throw new InvalidOperationException($"{nameof(Button)} requires one of {nameof(IsLightVersion)} or {nameof(IsDarkVersion)}, but both were specified.");

        base.OnParametersSet();
    }

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames =>
        CssUtility.BuildClassNames(
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
            (BulmaCssClass.IsSkeleton, IsSkeleton)
        );

    private string? ButtonTypeString => Type.ToButtonTypeString();

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

    /// <summary>
    /// Gets or sets the color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ButtonColor.None" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(ButtonColor.None)]
    [Description("Gets or sets the color.")]
    [Parameter] public ButtonColor Color { get; set; } = ButtonColor.None;

    /// <summary>
    /// Gets or sets the href.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the href.")]
    [Parameter] public string? Href { get; set; }

    /// <summary>
    /// If true, the dark version of the button will be enabled.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the dark version of the button will be enabled.")]
    [Parameter] public bool IsDarkVersion { get; set; }

    /// <summary>
    /// If true, the button will be disabled.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the button will be disabled.")]
    [Parameter] public bool IsDisabled { get; set; }

    /// <summary>
    /// If true, the button will be expanded to the full width of its container.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the button will be expanded to the full width of its container.")]
    [Parameter] public bool IsFullWidth { get; set; }

    /// <summary>
    /// If true, the inverted variant will be enabled.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the inverted variant will be enabled.")]
    [Parameter] public bool IsInverted { get; set; }

    /// <summary>
    /// If true, the light version of the button will be enabled.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the light version of the button will be enabled.")]
    [Parameter] public bool IsLightVersion { get; set; }

    /// <summary>
    /// If true, the button will be loading.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the button will be loading.")]
    [Parameter] public bool IsLoading { get; set; }

    /// <summary>
    /// If true, the outlined variant will be enabled.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the outlined variant will be enabled.")]
    [Parameter] public bool IsOutlined { get; set; }

    /// <summary>
    /// If true, the button will be responsive.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the button will be responsive.")]
    [Parameter] public bool IsResponsive { get; set; }

    /// <summary>
    /// If true, the rounded variant will be enabled.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the rounded variant will be enabled.")]
    [Parameter] public bool IsRounded { get; set; }

    /// <summary>
    /// If true, the skeleton variant will be enabled.
    /// </summary>
    /// <remarks>
    /// The default value is <see langword="false" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("If true, the skeleton variant will be enabled.")]
    [Parameter]
    public bool IsSkeleton { get; set; }

    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(ButtonSize.None)]
    [Description("Gets or sets the size.")]
    [Parameter] public ButtonSize Size { get; set; } = ButtonSize.None;

    /// <summary>
    /// Gets or sets the button type.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="ButtonType.Button" />.
    /// </remarks>
    [AddedVersion("1.0.0")]
    [DefaultValue(ButtonType.Button)]
    [Description("Gets or sets the button type.")]
    [Parameter]
    public ButtonType Type { get; set; } = ButtonType.Button;

    #endregion
}
