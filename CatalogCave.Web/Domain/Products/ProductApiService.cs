using System;
using CatalogCave.Application.Dtos;
using CatalogCave.Web.ViewModels.Filters;
using CatalogCave.Web.ViewModels.Products;

namespace CatalogCave.Web.Domain.Products;

public class ProductApiService(HttpClient httpClient, IConfiguration configs) : IProductApiService
{

    public async Task<IEnumerable<ProductViewModel>> GetAllAsync(PageRequestFilterViewModel filter)
    {
        var baseUrl = configs["ApiOptions:BaseUrl"];
        string query = $"?page={filter.Page}&pageSize={filter.PageSize}&category={filter.Category}&search={filter.Search}&sortBy={filter.SortBy}&descending={filter.Descending}";
        var result = await httpClient.GetFromJsonAsync<PagedResponseDto<ProductViewModel>>($"{baseUrl}/products{query}");
        return result?.Data ?? new List<ProductViewModel>();
    }

    public async Task<ProductViewModel?> GetByIdAsync(int id)
    {
        var baseUrl = configs["ApiOptions:BaseUrl"];
        return await httpClient.GetFromJsonAsync<ProductViewModel>($"{baseUrl}/products/{id}");
    }

}
