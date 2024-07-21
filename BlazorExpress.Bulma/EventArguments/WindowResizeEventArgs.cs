namespace BlazorExpress.Bulma;

public record WindowResizeEventArgs(DeviceType DeviceType, float Width);

public record MenuEventArgs(DeviceType DeviceType, float Width, bool IsVisible);
