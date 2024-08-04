namespace BlazorExpress.Bulma;

/// <summary>
/// Data provider (delegate).
/// </summary>
public delegate ValueTask<GridDataProviderResult<TItem>> GridDataProvider<TItem>(GridDataProviderRequest<TItem> request);
