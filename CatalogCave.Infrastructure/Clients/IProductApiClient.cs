using System;
using CatalogCave.Domain.Models;

namespace CatalogCave.Infrastructure.Clients;

public interface IProductApiClient
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);

}
