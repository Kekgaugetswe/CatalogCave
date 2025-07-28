using CatalogCave.Application.Dtos;
using CatalogCave.Application.Interfaces;
using CatalogCave.Common.Helpers;
using CatalogCave.Domain.Models;
using CatalogCave.Infrastructure.Clients;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CatalogCave.Infrastructure.Services;

public class ProductService(IMemoryCache cache, IProductApiClient apiClient, ILogger<ProductService> logger) : IProductService
{
    private const string CacheKey = "all_products";
    public async Task<PagedResponseDto<Product>> GetAllAsync(PagedRequestFilterDto filter)
    {
        try
        {
            // Try to get cached product list
            if (!cache.TryGetValue(CacheKey, out List<Product>? allProducts))
            {
                allProducts = (await apiClient.GetAllAsync() ?? new List<Product>()).ToList();
                cache.Set(CacheKey, allProducts, TimeSpan.FromMinutes(5));
            }

            // Ensure non-null fallback
            IEnumerable<Product> filtered = allProducts ?? Enumerable.Empty<Product>();

            // 🔍 Apply search
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                string searchTerm = filter.Search.ToLower();
                filtered = filtered.Where(p =>
                    (!string.IsNullOrWhiteSpace(p.Title) && p.Title.ToLower().Contains(searchTerm)) ||
                    (!string.IsNullOrWhiteSpace(p.Description) && p.Description.ToLower().Contains(searchTerm))
                );
            }

            //Filter by category
            if (!string.IsNullOrWhiteSpace(filter.Category))
            {
                filtered = filtered.Where(p =>
                    p.Category != null && p.Category.Contains(filter.Category, StringComparison.OrdinalIgnoreCase));
            }

            //Sort
            if (!string.IsNullOrWhiteSpace(filter.SortBy))
            {
                var sortBy = filter.SortBy.ToLower();

                filtered = sortBy switch
                {
                    "title" => filter.Descending
                        ? filtered.OrderByDescending(p => p.Title)
                        : filtered.OrderBy(p => p.Title),
                    "price" => filter.Descending
                        ? filtered.OrderByDescending(p => p.Price)
                        : filtered.OrderBy(p => p.Price),
                    _ => filtered
                };
            }

            int totalItems = filtered.Count();

            // Apply pagination
            filtered = filtered
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize);

            logger.LogInformation(AppMessages.FormatMessage(AppMessages.RetrieveAll, nameof(Product)));

            // Return paged response
            return new PagedResponseDto<Product>
            {
                Data = filtered,
                TotalItems = totalItems,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, AppMessages.FormatMessage(AppMessages.Unsuccessful, nameof(Product)));
            return new PagedResponseDto<Product>
            {
                Data = Enumerable.Empty<Product>(),
                TotalItems = 0,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }
    }


    public async Task<Product?> GetByIdAsync(int id)
    {
        return await apiClient.GetByIdAsync(id);
    }
}
