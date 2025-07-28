using System;
using CatalogCave.Web.ViewModels.Ratings;

namespace CatalogCave.Web.ViewModels.Products;

public class ProductViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public decimal Price { get; set; }
    public string Description { get; set; } = "";
    public string Category { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public RatingViewModel Rating { get; set; } = new();

}
