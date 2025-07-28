using System;
using CatalogCave.Application.Dtos;
using CatalogCave.Domain.Models;

namespace CatalogCave.Application.Interfaces;

public interface IProductService
{
    Task<PagedResponseDto<Product>> GetAllAsync(PagedRequestFilterDto filter);
    Task<Product?> GetByIdAsync(int id);
}

