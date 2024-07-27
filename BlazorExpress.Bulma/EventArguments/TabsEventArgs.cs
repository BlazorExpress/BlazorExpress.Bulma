namespace BlazorExpress.Bulma;

public class TabsEventArgs : EventArgs
{
    public TabsEventArgs(Tab activeTab, Tab previousActiveTab)
    {
        ActiveTab = activeTab;
        PreviousActiveTab = previousActiveTab;
    }

    public Tab ActiveTab { get; }

    public Tab PreviousActiveTab { get; }
}
