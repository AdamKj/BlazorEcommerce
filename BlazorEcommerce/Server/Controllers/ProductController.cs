using BlazorEcommerce.Shared.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("admin"), Authorize(Roles = "Admin")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetAdminProducts()
    {
        var result = await _productService.GetAdminProducts();
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
    {
        var result = await _productService.GetProducts();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetSingleProduct(int id)
    {
        var result = await _productService.GetSingleProduct(id);
        return Ok(result);
    }

    [HttpGet("Category/{url}")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductsByCategory(string url)
    {
        var result = await _productService.GetProductsByCategory(url);
        return Ok(result);
    }

    [HttpGet("search/{searchText}/{page}")]
    public async Task<ActionResult<ServiceResponse<ProductSearchResultDTO>>> SearchProducts(string searchText, int page = 1)
    {
        var result = await _productService.SearchProducts(searchText, page);
        return Ok(result);
    }

    [HttpGet("search-suggestions/{searchText}")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProductSearchSuggestions(string searchText)
    {
        var result = await _productService.GetProductSearchSuggestion(searchText);
        return Ok(result);
    }

    [HttpGet("featured")]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetFeaturedProducts()
    {
        var result = await _productService.GetFeaturedProducts();
        return Ok(result);
    }
}