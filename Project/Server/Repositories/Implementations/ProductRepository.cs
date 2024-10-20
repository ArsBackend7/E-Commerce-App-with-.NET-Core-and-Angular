using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Entities.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _context.Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? category)
    {
        IQueryable<Product> query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(brand))
        {
            query = query.Where(q => q.Brand == brand);
        }

        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(q => q.Category == category);
        }

        return await query.AsNoTracking().ToListAsync();
    }

    public IReadOnlyList<Product> GetProductsFiltered(string? sort)
    {
        IQueryable<Product> query = _context.Products.AsNoTracking();

        IOrderedEnumerable<Product> products = sort switch
        {
            "priceAsc" => query.AsEnumerable().OrderBy(q => q.Price),
            "priceDesc" => query.AsEnumerable().OrderByDescending(q => q.Price),
            _ => query.AsEnumerable().OrderBy(q => q.Name)
        };

        return products.ToList();
    }

    public async Task<IReadOnlyList<string>> GetBrandsAsync()
    {
        return await _context.Products
            .Select(p => p.Brand)
            .Distinct()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<string>> GetCategoriesAsync()
    {
        return await _context.Products
            .Select(p => p.Category)
            .Distinct()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Product?> GetProductAsync(int productId)
    {
        return await _context.Products.FindAsync(productId);
    }

    public async Task AddProductAsync(Product product)
    {
        _ = await _context.Products.AddAsync(product);
    }

    public void UpdateProductAsync(Product product)
    {
        _context.Entry(product).State = EntityState.Modified;
    }

    public void DeleteProductAsync(Product product)
    {
        _ = _context.Products.Remove(product);
    }

    public async Task<bool> ProductExistsAsync(int productId)
    {
        return await _context.Products.AnyAsync(e => e.Id == productId);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
