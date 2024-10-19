using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Entities.Models;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly DataContext _context;

    public ProductController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("get-products")]
    public async Task<IActionResult> GetProducts()
    {
        List<Product> products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    [HttpGet]
    [Route("get-product")]
    public async Task<IActionResult> GetProduct(int productId)
    {
        Product? product = await _context.Products.FindAsync(productId);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    [Route("create-product")]
    public async Task<IActionResult> PostProduct(Product product)
    {
        _ = await _context.Products.AddAsync(product);
        _ = await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProduct), new { productId = product.Id }, product);
    }

    [HttpPut]
    [Route("update-product")]
    public async Task<IActionResult> PutProduct(int productId, Product product)
    {
        if (productId != product.Id)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;

        try
        {
            _ = await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await ProductExists(productId))
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
        Product? product = await _context.Products.FindAsync(productId);

        if (product == null)
        {
            return NotFound();
        }

        _ = _context.Products.Remove(product);
        _ = await _context.SaveChangesAsync();
        return NoContent();
    }

    private async Task<bool> ProductExists(int productId)
    {
        return await _context.Products.AnyAsync(e => e.Id == productId);
    }
}
