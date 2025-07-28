using System;

namespace CatalogCave.Infrastructure.Configurations;

public class FakeStoreApiOptions
{

    /// <summary>
    /// The base URl of the foreStoreAPI  and the endpoints uterlized
    /// </summary>

    public string BaseUrl { get; set; } = string.Empty;
    public string ProductsEndpoint { get; set; } =string.Empty;
    public string ProductByIdEndpoint { get; set; } = string.Empty;

}
