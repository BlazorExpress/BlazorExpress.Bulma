namespace BlazorExpress.Bulma;

/// <summary>
/// SplitView component with draggable panes.
/// </summary>
public partial class SplitView : BulmaComponentBase, IAsyncDisposable
{
    #region Fields and Constants

    private double currentPrimaryPaneSize = 50;
    private DotNetObjectReference<SplitView>? objRef;
    private bool parametersInitialized;
    private double previousMinimumPaneSizeParameter = 10;
    private double previousPrimaryPaneSizeParameter = 50;

    #endregion

    #region Methods

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
            await JSRuntime.InvokeVoidAsync(SplitViewJsInterop.Initialize, Id, GetJsOptions(), objRef);
        else
            await JSRuntime.InvokeVoidAsync(SplitViewJsInterop.Update, Id, GetJsOptions());

        await base.OnAfterRenderAsync(firstRender);
    }

    protected override async Task OnInitializedAsync()
    {
        objRef ??= DotNetObjectReference.Create(this);

        await base.OnInitializedAsync();
    }

    protected override void OnParametersSet()
    {
        ValidateParameters();

        if (!parametersInitialized
            || PrimaryPaneSize != previousPrimaryPaneSizeParameter
            || MinimumPaneSize != previousMinimumPaneSizeParameter)
        {
            currentPrimaryPaneSize = ClampPrimaryPaneSize(PrimaryPaneSize);
            previousPrimaryPaneSizeParameter = PrimaryPaneSize;
            previousMinimumPaneSizeParameter = MinimumPaneSize;
            parametersInitialized = true;
        }

        base.OnParametersSet();
    }

    [JSInvokable]
    public async Task OnResizeStartedJS(double primaryPaneSize, double secondaryPaneSize)
    {
        currentPrimaryPaneSize = ClampPrimaryPaneSize(primaryPaneSize);

        if (OnResizeStarted.HasDelegate)
            await OnResizeStarted.InvokeAsync(CreateResizeEventArgs(primaryPaneSize, secondaryPaneSize));
    }

    [JSInvokable]
    public async Task OnResizedJS(double primaryPaneSize, double secondaryPaneSize)
    {
        currentPrimaryPaneSize = ClampPrimaryPaneSize(primaryPaneSize);

        if (PrimaryPaneSizeChanged.HasDelegate)
            await PrimaryPaneSizeChanged.InvokeAsync(currentPrimaryPaneSize);

        if (OnResized.HasDelegate)
            await OnResized.InvokeAsync(CreateResizeEventArgs(primaryPaneSize, secondaryPaneSize));
    }

    [JSInvokable]
    public async Task OnResizeEndedJS(double primaryPaneSize, double secondaryPaneSize)
    {
        currentPrimaryPaneSize = ClampPrimaryPaneSize(primaryPaneSize);

        if (OnResizeEnded.HasDelegate)
            await OnResizeEnded.InvokeAsync(CreateResizeEventArgs(primaryPaneSize, secondaryPaneSize));

        await InvokeAsync(StateHasChanged);
    }

    private double ClampPrimaryPaneSize(double primaryPaneSize) =>
        Math.Min(100 - MinimumPaneSize, Math.Max(MinimumPaneSize, primaryPaneSize));

    private object GetJsOptions() =>
        new
        {
            isDisabled = IsDisabled,
            isHorizontal = Orientation == SplitViewOrientation.Horizontal,
            minimumPaneSize = MinimumPaneSize,
            notifyResize = PrimaryPaneSizeChanged.HasDelegate || OnResized.HasDelegate,
            notifyResizeStarted = OnResizeStarted.HasDelegate,
            primaryPaneSize = currentPrimaryPaneSize
        };

    private SplitViewResizeEventArgs CreateResizeEventArgs(double primaryPaneSize, double secondaryPaneSize)
    {
        var clampedPrimaryPaneSize = ClampPrimaryPaneSize(primaryPaneSize);

        return new(clampedPrimaryPaneSize, 100 - clampedPrimaryPaneSize, Orientation);
    }

    private void ValidateParameters()
    {
        if (MinimumPaneSize < 0 || MinimumPaneSize >= 50)
            throw new InvalidOperationException($"{nameof(SplitView)} requires {nameof(MinimumPaneSize)} to be between 0 and less than 50.");

        if (PrimaryPaneSize < MinimumPaneSize || PrimaryPaneSize > 100 - MinimumPaneSize)
            throw new InvalidOperationException($"{nameof(SplitView)} requires {nameof(PrimaryPaneSize)} to be between {MinimumPaneSize} and {100 - MinimumPaneSize}.");
    }

    #endregion

    #region Properties, Indexers

    private string AriaDisabled => IsDisabled ? "true" : "false";

    private string AriaValueNow => currentPrimaryPaneSize.ToString("0.##", CultureInfo.InvariantCulture);

    protected override string? ClassNames =>
        BuildClassNames(
            Class,
            (BulmaCssClass.SplitView, true),
            (Orientation.ToSplitViewOrientationClass(), true),
            (BulmaCssClass.SplitViewDisabled, IsDisabled)
        );

    private string? DividerClassNames =>
        BuildClassNames(
            BulmaCssClass.SplitViewDivider,
            (BulmaCssClass.SplitViewDividerDisabled, IsDisabled)
        );

    /// <summary>
    /// Gets or sets the Bulma semantic color used for divider state defaults.
    /// <para>
    /// Default value is <see cref="SplitViewColor.None" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(SplitViewColor.None)]
    [Description("Gets or sets the Bulma semantic color used for divider state defaults.")]
    [Parameter]
    public SplitViewColor Color { get; set; } = SplitViewColor.None;

    /// <summary>
    /// Gets or sets the divider background color.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the divider background color.")]
    [Parameter]
    public string? DividerBackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets the divider dragging background color.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the divider dragging background color.")]
    [Parameter]
    public string? DividerDraggingBackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets the divider hover background color.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the divider hover background color.")]
    [Parameter]
    public string? DividerHoverBackgroundColor { get; set; }

    /// <summary>
    /// If <see langword="true" />, dragging is disabled.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(false)]
    [Description("If <b>true</b>, dragging is disabled.")]
    [Parameter]
    public bool IsDisabled { get; set; } = false;

    /// <summary>
    /// Gets or sets the minimum size, in percentage, that either pane can occupy.
    /// <para>
    /// Default value is 10.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(10d)]
    [Description("Gets or sets the minimum size, in percentage, that either pane can occupy.")]
    [Parameter]
    public double MinimumPaneSize { get; set; } = 10;

    /// <summary>
    /// Gets or sets the resize end event.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("This event fires when a drag resize operation ends.")]
    [Parameter]
    public EventCallback<SplitViewResizeEventArgs> OnResizeEnded { get; set; }

    /// <summary>
    /// Gets or sets the resize move event.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("This event fires while the divider is being dragged.")]
    [Parameter]
    public EventCallback<SplitViewResizeEventArgs> OnResized { get; set; }

    /// <summary>
    /// Gets or sets the resize start event.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("This event fires when a drag resize operation starts.")]
    [Parameter]
    public EventCallback<SplitViewResizeEventArgs> OnResizeStarted { get; set; }

    /// <summary>
    /// Gets or sets the split orientation.
    /// <para>
    /// Default value is <see cref="SplitViewOrientation.Horizontal" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(SplitViewOrientation.Horizontal)]
    [Description("Gets or sets the split orientation.")]
    [Parameter]
    public SplitViewOrientation Orientation { get; set; } = SplitViewOrientation.Horizontal;

    /// <summary>
    /// Gets or sets the first pane content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the first pane content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? Pane1 { get; set; }

    /// <summary>
    /// Gets or sets the second pane content.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the second pane content.")]
    [EditorRequired]
    [Parameter]
    public RenderFragment? Pane2 { get; set; }

    private string? PrimaryPaneClassNames =>
        BuildClassNames(
            BulmaCssClass.SplitViewPane,
            (BulmaCssClass.SplitViewPanePrimary, true)
        );

    /// <summary>
    /// Gets or sets the first pane size, in percentage.
    /// <para>
    /// Default value is 50.
    /// </para>
    /// </summary>
    [AddedVersion("1.2.0")]
    [DefaultValue(50d)]
    [Description("Gets or sets the first pane size, in percentage.")]
    [Parameter]
    public double PrimaryPaneSize { get; set; } = 50;

    /// <summary>
    /// This event fires when the first pane size changes.
    /// </summary>
    [AddedVersion("1.2.0")]
    [Description("This event fires when the first pane size changes.")]
    [Parameter]
    public EventCallback<double> PrimaryPaneSizeChanged { get; set; }

    private string? SecondaryPaneClassNames =>
        BuildClassNames(
            BulmaCssClass.SplitViewPane,
            (BulmaCssClass.SplitViewPaneSecondary, true)
        );

    private string SeparatorOrientation => Orientation == SplitViewOrientation.Horizontal ? "vertical" : "horizontal";

    protected override string? StyleNames =>
        BuildStyleNames(
            Style,
            ($"--be-bulma-split-view-divider-base-color: {Color.ToSplitViewDividerColorCssValue()};", Color != SplitViewColor.None),
            ($"--be-bulma-split-view-divider-background-color: {DividerBackgroundColor};", !string.IsNullOrWhiteSpace(DividerBackgroundColor)),
            ($"--be-bulma-split-view-divider-dragging-background-color: {DividerDraggingBackgroundColor};", !string.IsNullOrWhiteSpace(DividerDraggingBackgroundColor)),
            ($"--be-bulma-split-view-divider-hover-background-color: {DividerHoverBackgroundColor};", !string.IsNullOrWhiteSpace(DividerHoverBackgroundColor)),
            ($"--be-bulma-split-view-primary-pane-size: {currentPrimaryPaneSize.ToString("0.##", CultureInfo.InvariantCulture)}%;", true),
            ($"--be-bulma-split-view-minimum-pane-size: {MinimumPaneSize.ToString("0.##", CultureInfo.InvariantCulture)}%;", true)
        );

    #endregion

    #region Explicit Interface Implementations

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        try
        {
            await JSRuntime.InvokeVoidAsync(SplitViewJsInterop.Dispose, Id);
        }
        catch
        {
        }

        objRef?.Dispose();
    }

    #endregion
}
