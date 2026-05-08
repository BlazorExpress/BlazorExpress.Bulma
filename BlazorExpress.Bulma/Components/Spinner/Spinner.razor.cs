namespace BlazorExpress.Bulma;

/// <summary>
/// Spinner component aligned with Bulma color and size helpers.
/// </summary>
public partial class Spinner : BulmaComponentBase
{
    #region Fields and Constants

    private bool isVisible = true;
    private bool previousIsVisible = true;

    #endregion

    #region Methods

    protected override void OnParametersSet()
    {
        if (IsVisible != previousIsVisible)
        {
            isVisible = IsVisible;
            previousIsVisible = IsVisible;
        }

        base.OnParametersSet();
    }

    /// <summary>
    /// Hides the spinner.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Hides the spinner.")]
    public void Hide()
    {
        if (!isVisible) return;

        isVisible = false;

        StateHasChanged();
    }

    /// <summary>
    /// Shows the spinner.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("Shows the spinner.")]
    public void Show()
    {
        if (isVisible) return;

        isVisible = true;

        StateHasChanged();
    }

    #endregion

    #region Properties, Indexers

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.Spinner, true),
            (Type.ToSpinnerTypeClass(), true),
            (Color.ToSpinnerColorClass(), Color != SpinnerColor.None),
            (Size.ToSpinnerSizeClass(), Size != SpinnerSize.None)
        );

    private string? AriaHidden => HasAccessibleLabel ? null : "true";

    /// <summary>
    /// Gets or sets the spinner color from the Bulma semantic palette.
    /// <para>
    /// Default value is <see cref="SpinnerColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(SpinnerColor.None)]
    [Description("Gets or sets the spinner color from the Bulma semantic palette.")]
    [Parameter]
    public SpinnerColor Color { get; set; } = SpinnerColor.None;

    private bool HasAccessibleLabel => !string.IsNullOrWhiteSpace(Label);

    /// <summary>
    /// If <see langword="true" />, the spinner is visible.
    /// <para>
    /// Default value is <see langword="true" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(true)]
    [Description("If <b>true</b>, the spinner is visible.")]
    [Parameter]
    public bool IsVisible { get; set; } = true;

    /// <summary>
    /// Gets or sets the accessible label announced by screen readers.
    /// <para>
    /// Default value is <c>Loading...</c>.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue("Loading...")]
    [Description("Gets or sets the accessible label announced by screen readers.")]
    [Parameter]
    public string Label { get; set; } = "Loading...";

    private string Role => HasAccessibleLabel ? "status" : "presentation";

    /// <summary>
    /// Gets or sets the spinner size from the Bulma size scale.
    /// <para>
    /// Default value is <see cref="SpinnerSize.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(SpinnerSize.None)]
    [Description("Gets or sets the spinner size from the Bulma size scale.")]
    [Parameter]
    public SpinnerSize Size { get; set; } = SpinnerSize.None;

    /// <summary>
    /// Gets or sets the spinner type.
    /// <para>
    /// Default value is <see cref="SpinnerType.Border" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(SpinnerType.Border)]
    [Description("Gets or sets the spinner type.")]
    [Parameter]
    public SpinnerType Type { get; set; } = SpinnerType.Border;

    #endregion
}
