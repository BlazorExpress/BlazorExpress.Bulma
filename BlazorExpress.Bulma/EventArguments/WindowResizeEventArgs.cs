namespace BlazorExpress.Bulma;

public class WindowResizeEventArgs : EventArgs
{
    #region Constructors

    public WindowResizeEventArgs(DeviceType deviceType, float width)
    {
        DeviceType = deviceType;
        Width = width;
    }

    #endregion

    #region Properties, Indexers

    public DeviceType DeviceType { get; }

    public float Width { get; }

    #endregion
}
