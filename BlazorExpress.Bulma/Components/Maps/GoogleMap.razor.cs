namespace BlazorExpress.Bulma;

/// <summary>
/// Google Map component
/// <para>
///     <see href="https://developers.google.com/maps/documentation/javascript/tutorial" />
/// </para>
/// </summary>
public partial class GoogleMap : BulmaComponentBase
{
    #region Fields and Constants

    private DotNetObjectReference<GoogleMap>? objRef;

    #endregion

    #region Methods

    protected override async Task OnInitializedAsync()
    {
        objRef ??= DotNetObjectReference.Create(this);

        await base.OnInitializedAsync();
    }

    /// <summary>
    /// Adds a marker to the GoogleMap.
    /// </summary>
    /// <param name="marker">The marker to add to the map.</param>
    /// <returns>A completed task.</returns>
    [AddedVersion("1.0.0")]
    [Description("Adds a marker to the GoogleMap.")]
    public ValueTask AddMarkerAsync(GoogleMapMarker marker)
    {
        JSRuntime.InvokeVoidAsync(GoogleMapInterop.AddMarker, Id, marker, objRef);

        return ValueTask.CompletedTask;
    }

    [JSInvokable]
    public async Task OnMarkerClickJS(GoogleMapMarker marker)
    {
        if (OnMarkerClick.HasDelegate)
            await OnMarkerClick.InvokeAsync(marker);
    }

    /// <summary>
    /// Refreshes the Google Maps component.
    /// </summary>
    /// <returns>A completed task.</returns>
    [AddedVersion("1.0.0")]
    [Description("Refreshes the Google Maps component.")]
    public ValueTask RefreshAsync()
    {
        JSRuntime.InvokeVoidAsync(GoogleMapInterop.Initialize, Id, Zoom, Center, Markers, Clickable, objRef);

        return ValueTask.CompletedTask;
    }

    /// <summary>
    /// Updates the markers on the Google Map.
    /// </summary>
    /// <returns>A completed task.</returns>
    [AddedVersion("1.0.0")]
    [Description("Updates the markers on the Google Map.")]
    public ValueTask UpdateMarkersAsync(IEnumerable<GoogleMapMarker> markers)
    {
        JSRuntime.InvokeVoidAsync(GoogleMapInterop.UpdateMarkers, Id, markers, objRef);

        return ValueTask.CompletedTask;
    }

    private void OnScriptLoad()
    {
        Console.WriteLine("OnScriptLoad called...");
        Task.Run(async () => await JSRuntime.InvokeVoidAsync(GoogleMapInterop.Initialize, Id, Zoom, Center, Markers, Clickable, objRef));
    }

    #endregion

    #region Properties, Indexers

    protected override string? StyleNames =>
        BuildStyleNames(
            Style,
            ($"width:{Width!.Value.ToString(CultureInfo.InvariantCulture)}{WidthUnit.ToUnitCssString()}", Width is not null && Width.Value > 0),
            ($"height:{Height!.Value.ToString(CultureInfo.InvariantCulture)}{HeightUnit.ToUnitCssString()}", Height is not null && Height.Value > 0)
        );

    /// <summary>
    /// Gets or sets the Google Maps API key.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the Google Maps API key.")]
    [EditorRequired]
    [Parameter]
    public string? ApiKey { get; set; } = null;

    /// <summary>
    /// Gets or sets the center parameter.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the center parameter.")]
    [Parameter]
    public GoogleMapCenter Center { get; set; } = default!;

    /// <summary>
    /// Makes the marker clickable if set to <see langword="true" />.
    /// <para>
    /// Default value is <see langword="false" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(false)]
    [Description("Makes the marker clickable if set to <b>true</b>.")]
    [Parameter]
    public bool Clickable { get; set; } = false;

    private string? GoogleMapsJsFileUrl => $"https://maps.googleapis.com/maps/api/js?key={ApiKey}&libraries=maps,marker";

    /// <summary>
    /// Gets or sets the height of the <see cref="GoogleMap" />.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the height of the <code>GoogleMap</code>.")]
    [Parameter]
    public double? Height { get; set; }

    /// <summary>
    /// Gets or sets the units for the <see cref="Height" />.
    /// <para>
    /// Default value is <see cref="Unit.Px" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(Unit.Px)]
    [Description("Gets or sets the units for the <code>Height</code>.")]
    [Parameter]
    public Unit HeightUnit { get; set; } = Unit.Px;

    /// <summary>
    /// Gets or sets the markers.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the markers.")]
    [Parameter]
    public IEnumerable<GoogleMapMarker>? Markers { get; set; }

    /// <summary>
    /// Event fired when a user clicks on a marker.
    /// This event fires only when <see cref="Clickable" /> is set to <see langword="true" />.
    /// </summary>
    [AddedVersion("1.0.0")]
    [Description("This event is fired when a user clicks on a marker. It fires only when <code>Clickable</code> is set to <b>true</b>.")]
    [Parameter]
    public EventCallback<GoogleMapMarker> OnMarkerClick { get; set; }

    /// <summary>
    /// Gets or sets the width of the <see cref="GoogleMap" />.
    /// <para>
    /// Default value is <see langword="null" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(null)]
    [Description("Gets or sets the width of the <code>GoogleMap</code>.")]
    [Parameter]
    public double? Width { get; set; }

    /// <summary>
    /// Gets or sets the units for the <see cref="Width" />.
    /// <para>
    /// Default value is <see cref="Unit.Percentage" />.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(Unit.Percentage)]
    [Description("Gets or sets the units for the <code>Width</code>.")]
    [Parameter]
    public Unit WidthUnit { get; set; } = Unit.Percentage;

    /// <summary>
    /// Gets or sets the zoom level of the <see cref="GoogleMap" />.
    /// <para>
    /// Default value is 14.
    /// </para>
    /// </summary>
    [AddedVersion("1.0.0")]
    [DefaultValue(14)]
    [Description("Gets or sets the zoom level of the <code>GoogleMap</code>.")]
    [Parameter]
    public int Zoom { get; set; } = 14;

    #endregion
}
