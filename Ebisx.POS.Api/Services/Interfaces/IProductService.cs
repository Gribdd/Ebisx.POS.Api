using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(Guid id);
        Task<Product> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Guid id, Product product);
        Task<bool> DeleteProductAsync(Guid id);
    }
}
