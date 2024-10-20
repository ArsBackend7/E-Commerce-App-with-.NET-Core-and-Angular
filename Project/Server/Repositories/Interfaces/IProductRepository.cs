using Server.Entities.Models;

namespace Server.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IReadOnlyList<Product>> GetProductsAsync();
    Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? category);
    IReadOnlyList<Product> GetProductsFiltered(string? sort);
    Task<IReadOnlyList<string>> GetBrandsAsync();
    Task<IReadOnlyList<string>> GetCategoriesAsync();
    Task<Product?> GetProductAsync(int productId);
    Task AddProductAsync(Product product);
    void UpdateProductAsync(Product product);
    void DeleteProductAsync(Product product);
    Task<bool> ProductExistsAsync(int productId);
    Task<bool> SaveChangesAsync();
}
