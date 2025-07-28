using CatalogCave.Application.Dtos;
using CatalogCave.Application.Interfaces;
using CatalogCave.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogCave.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService service) : ControllerBase
    {

        [HttpGet]
    public async Task<ActionResult<PagedResponseDto<Product>>> GetAll([FromQuery] PagedRequestFilterDto filter)
    {
        var products = await service.GetAllAsync(filter);
        return Ok(products);
    }

    // GET: /api/products/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await service.GetByIdAsync(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }
    }
}
