namespace BlazorExpress.Bulma;

public class TabEventArgs
{
    #region Constructors

    public TabEventArgs(Tab tab)
    {
        Tab = tab;
    }

    #endregion

    #region Properties, Indexers

    public Tab Tab { get; }

    #endregion
}
