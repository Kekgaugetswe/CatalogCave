using CatalogCave.Application.Interfaces;
using CatalogCave.Infrastructure.Clients;
using CatalogCave.Infrastructure.Configurations;
using CatalogCave.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CatalogCave.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<FakeStoreApiOptions>(configuration.GetSection("FakeStoreApi"));
        services.AddHttpClient<IProductApiClient, ProductApiClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<FakeStoreApiOptions>>().Value;
            client.BaseAddress = new Uri(options.BaseUrl);
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        }); ;

        services.AddMemoryCache();
        services.AddLogging();
        services.AddScoped<IProductService, ProductService>();
        return services;


    }

}
