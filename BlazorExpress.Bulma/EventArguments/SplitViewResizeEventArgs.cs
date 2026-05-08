namespace BlazorExpress.Bulma;

public class SplitViewResizeEventArgs : EventArgs
{
    #region Constructors

    public SplitViewResizeEventArgs(double primaryPaneSize, double secondaryPaneSize, SplitViewOrientation orientation)
    {
        Orientation = orientation;
        PrimaryPaneSize = primaryPaneSize;
        SecondaryPaneSize = secondaryPaneSize;
    }

    #endregion

    #region Properties, Indexers

    public SplitViewOrientation Orientation { get; }

    public double PrimaryPaneSize { get; }

    public double SecondaryPaneSize { get; }

    #endregion
}
