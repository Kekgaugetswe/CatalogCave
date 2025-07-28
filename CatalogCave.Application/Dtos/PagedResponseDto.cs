using System;

namespace CatalogCave.Application.Dtos;

public class PagedResponseDto<T>
{
    public IEnumerable<T> Data { get; set; } = new List<T>();
    public int TotalItems { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }

}
