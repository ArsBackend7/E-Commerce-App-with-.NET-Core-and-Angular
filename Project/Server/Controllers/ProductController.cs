using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Entities.Models;
using Server.Repositories.Interfaces;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    [Route("get-products")]
    public async Task<IActionResult> GetProducts()
    {
        IReadOnlyList<Product> products = await _productRepository.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet]
    [Route("get-products-of-specific-brand-and-category")]
    public async Task<IActionResult> GetProducts(string? brand, string? category)
    {
        IReadOnlyList<Product> products = await _productRepository.GetProductsAsync(brand, category);
        return Ok(products);
    }

    [HttpGet]
    [Route("get-products-by-filtering")]
    [ProducesResponseType(typeof(IReadOnlyList<Product>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GetProductsFiltered(string? sort)
    {
        IReadOnlyList<Product> products = _productRepository.GetProductsFiltered(sort);
        return Ok(products);
    }

    [HttpGet]
    [Route("get-brands")]
    public async Task<IActionResult> GetBrands()
    {
        IReadOnlyList<string> brands = await _productRepository.GetBrandsAsync();
        return Ok(brands);
    }

    [HttpGet]
    [Route("get-categories")]
    public async Task<IActionResult> GetCategories()
    {
        IReadOnlyList<string> categories = await _productRepository.GetCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet]
    [Route("get-product")]
    public async Task<IActionResult> GetProduct(int productId)
    {
        Product? product = await _productRepository.GetProductAsync(productId);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    [Route("create-product")]
    public async Task<IActionResult> PostProduct(Product product)
    {
        if (product == null)
        {
            return BadRequest("Product cannot be null.");
        }

        await _productRepository.AddProductAsync(product);

        bool isSaved = await _productRepository.SaveChangesAsync();

        return !isSaved
            ? StatusCode(StatusCodes.Status500InternalServerError, "Error saving product.")
            : CreatedAtAction(nameof(GetProduct), new { productId = product.Id }, product);
    }

    [HttpPut]
    [Route("update-product")]
    public async Task<IActionResult> PutProduct(int productId, Product product)
    {
        if (productId != product.Id)
        {
            return BadRequest();
        }

        _productRepository.UpdateProductAsync(product);

        try
        {
            bool isSaved = await _productRepository.SaveChangesAsync();

            if (!isSaved)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating product.");
            }
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _productRepository.ProductExistsAsync(productId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete]
    [Route("delete-product")]
    public async Task<IActionResult> DeleteProduct(int productId)
    {
        Product? product = await _productRepository.GetProductAsync(productId);

        if (product == null)
        {
            return NotFound();
        }

        _productRepository.DeleteProductAsync(product);
        bool isDeleted = await _productRepository.SaveChangesAsync();
        return !isDeleted ? StatusCode(StatusCodes.Status500InternalServerError, "Error deleting product.") : NoContent();
    }
}
