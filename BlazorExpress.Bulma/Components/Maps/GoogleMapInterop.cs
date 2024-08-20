namespace BlazorExpress.Bulma;

public class GoogleMapInterop
{
    #region Fields and Constants

    private const string Prefix = "window.blazorExpress.googlemaps.";

    public const string Initialize = Prefix + "initialize";

    public const string AddMarker = Prefix + "addMarker";

    public const string UpdateMarkers = Prefix + "updateMarkers";

    #endregion
}
