namespace BlazorExpress.Bulma;

public class TabsEventArgs : EventArgs
{
    #region Constructors

    public TabsEventArgs(Tab activeTab, Tab previousActiveTab)
    {
        ActiveTab = activeTab;
        PreviousActiveTab = previousActiveTab;
    }

    #endregion

    #region Properties, Indexers

    public Tab ActiveTab { get; }

    public Tab PreviousActiveTab { get; }

    #endregion
}
