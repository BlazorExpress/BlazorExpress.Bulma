namespace BlazorExpress.Bulma;

internal class SplitViewJsInterop
{
    #region Fields and Constants

    private const string Prefix = "window.blazorexpress.bulma.splitView.";

    public const string Dispose = Prefix + "dispose";
    public const string Initialize = Prefix + "initialize";
    public const string Update = Prefix + "update";

    #endregion
}
