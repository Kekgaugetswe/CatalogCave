using System;
using CatalogCave.Web.ViewModels.Filters;
using CatalogCave.Web.ViewModels.Products;

namespace CatalogCave.Web.Domain.Products;

public interface IProductApiService
{
    Task<IEnumerable<ProductViewModel>> GetAllAsync(PageRequestFilterViewModel filter);
    Task<ProductViewModel?> GetByIdAsync(int id);

}
