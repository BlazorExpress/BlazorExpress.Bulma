namespace BlazorExpress.Bulma;

public class TabEventArgs
{
    public TabEventArgs(Tab activeTab)
    {
        ActiveTab = activeTab;
    }

    public Tab ActiveTab { get; }
}
