namespace BlazorExpress.Bulma;

/// <summary>
/// Data provider (delegate).
/// </summary>
public delegate ValueTask<GridItemsProviderResult<TItem>> GridItemsProvider<TItem>(GridItemsProviderRequest<TItem> request);