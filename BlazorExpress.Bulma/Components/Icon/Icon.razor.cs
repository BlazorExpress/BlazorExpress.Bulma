namespace BlazorExpress.Bulma;

public partial class Icon : BulmaComponentBase
{
    #region Methods

    //protected override void OnParametersSet()
    //{
    //    base.OnParametersSet();
    //}

    #endregion

    #region Properties, Indexers

    protected override string? CssClassNames
        => CssUtility.BuildClassNames(
            Class,
            (BootstrapIconUtility.Icon(), BootstrapIcon != BootstrapIcon.None),
            (BootstrapIconUtility.Icon(BootstrapIcon), BootstrapIcon != BootstrapIcon.None),
            (Color.ToIconColorClass(), Color != IconColor.None),
            (Size.ToIconSizeClass(), Size != IconSize.None));

    /// <summary>
    /// If true, icon color is applied to the text.
    /// </summary>
    /// <remarks>
    /// The default value is <see cref="false" />.
    /// </remarks>
    [Parameter]
    public bool ApplyColorToText { get; set; }

    /// <summary>
    /// Gets or sets the child content.
    /// </summary>
    /// <remarks>
    /// Default value is <see langword="null"/>.
    /// </remarks>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Gets or sets the icon color.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconColor.None" />.
    /// </remarks>
    [Parameter]
    public IconColor Color { get; set; } = IconColor.None;

    /// <summary>
    /// Gets or sets the custom icon name.
    /// Specify custom icons of your own, like `fontawesome`. Example: `fas fa-alarm-clock`.
    /// </summary>
    /// <remarks>
    /// Default value is null.
    /// </remarks>
    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the bootstrap icon name.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconName.None" />.
    /// </remarks>
    [Parameter]
    public BootstrapIcon BootstrapIcon { get; set; } = BootstrapIcon.None;

    /// <summary>
    /// Gets or sets the icon size.
    /// </summary>
    /// <remarks>
    /// Default value is <see cref="IconSize.None" />.
    /// </remarks>
    [Parameter]
    public IconSize Size { get; set; } = IconSize.None;

    private string? TextCssClassNames
        => CssUtility.BuildClassNames(
            (@BulmaCssClass.IconText, true),
            (Color.ToIconColorClass(), Color != IconColor.None && ApplyColorToText));

    #endregion
}
