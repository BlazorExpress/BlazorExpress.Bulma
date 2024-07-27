namespace BlazorExpress.Bulma;

public class WindowResizeEventArgs : EventArgs {

    public WindowResizeEventArgs(DeviceType deviceType, float width)
    {
        DeviceType = deviceType;
        Width = width;
    }

    public DeviceType DeviceType { get; }

    public float Width { get; }
}
