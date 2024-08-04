namespace BlazorExpress.Bulma;

/// <summary>
/// Data provider (delegate).
/// </summary>
public delegate Task<GridDataProviderResult<TItem>> GridDataProvider<TItem>(GridDataProviderRequest<TItem> request);
