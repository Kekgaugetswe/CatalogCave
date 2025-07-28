using System;

namespace CatalogCave.Application.Dtos;

public class PagedRequestFilterDto
{
    public string? Search { get; set; }   
    public string? Category { get; set; }    
    public string? SortBy { get; set; }   
    public bool Descending { get; set; } = false;

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

}
