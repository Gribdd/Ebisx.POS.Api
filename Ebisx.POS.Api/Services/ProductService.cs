using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ebisx.POS.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateProductAsync(Guid id, Product updatedProduct)
        {
            var existingProduct = await _dbContext.Products.FindAsync(id);
            if (existingProduct == null) return false;

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProductAsync(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null) return false;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}
