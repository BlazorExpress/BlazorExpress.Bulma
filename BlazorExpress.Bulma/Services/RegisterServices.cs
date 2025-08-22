namespace BlazorExpress.Bulma;

public static class RegisterServices
{
    #region Methods

    /// <summary>
    /// Adds a bulma providers and component mappings.
    /// </summary>
    /// <param name="services"></param>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddBlazorExpressBulma(this IServiceCollection services)
    {
        services.AddScoped<PdfViewerJsInterop>();

        return services;
    }

    #endregion
}
