using System;
using System.Net.Http.Json;
using CatalogCave.Domain.Models;
using CatalogCave.Infrastructure.Configurations;
using CatalogCave.Infrastructure.Dtos;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CatalogCave.Common.Helpers;

namespace CatalogCave.Infrastructure.Clients;

public class ProductApiClient(HttpClient httpClient, IOptionsSnapshot<FakeStoreApiOptions> options, ILogger<ProductApiClient> logger) : IProductApiClient
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var endpoint = options.Value.ProductsEndpoint;

        try
        {
            var result = await httpClient.GetFromJsonAsync<List<ProductDto>>(endpoint);

            if (result == null || !result.Any())
            {
                logger.LogWarning(AppMessages.FormatMessage(AppMessages.NotFound, nameof(Product)));
                return Enumerable.Empty<Product>();
            }

            logger.LogInformation(AppMessages.FormatMessage(AppMessages.RetrieveAll, nameof(Product)));
            return result?.Select(dto => new Product
            {
                Id = dto.Id,
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,
                Category = dto.Category,
                ImageUrl = dto.Image,
                Rating = new Rating
                {
                    Rate = dto.Rating.Rate,
                    Count = dto.Rating.Count
                }

            }) ?? new List<Product>();

        }
        catch (Exception ex)
        {
            logger.LogError(ex, AppMessages.FormatMessage(AppMessages.Unsuccessful, nameof(Product)));
            return Enumerable.Empty<Product>();
        }


    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var endpoint = options.Value.ProductByIdEndpoint.Replace("{id}", id.ToString());

        try
        {

            var dto = await httpClient.GetFromJsonAsync<ProductDto>(endpoint);
            if (dto is null)
            {
                logger.LogWarning(AppMessages.FormatMessage(AppMessages.NotFound, nameof(Product)));
                return null;
            }

            logger.LogInformation(AppMessages.FormatMessage(AppMessages.RetrievedById, nameof(Product)));

            return new Product
            {
                Id = dto.Id,
                Title = dto.Title,
                Price = dto.Price,
                Description = dto.Description,
                Category = dto.Category,
                ImageUrl = dto.Image,
                Rating = new Rating
                {
                    Rate = dto.Rating.Rate,
                    Count = dto.Rating.Count
                }
            };

        }
        catch (Exception ex)
        {
            logger.LogError(ex, AppMessages.FormatMessage(AppMessages.Unsuccessful, nameof(Product)));
            return null;
        }

    }

}
