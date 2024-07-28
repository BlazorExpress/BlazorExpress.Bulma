namespace BlazorExpress.Bulma;

public class TabEventArgs
{
    public TabEventArgs(Tab tab)
    {
        Tab = tab;
    }

    public Tab Tab { get; }
}
