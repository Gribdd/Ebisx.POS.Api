using Ebisx.POS.Api.DTOs.Product;
using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
    Task<ProductResponseDto?> GetProductByIdAsync(int id);
    Task<ProductResponseDto> CreateProductAsync(ProductRequestDto product);
    Task<bool> UpdateProductAsync(int id, ProductRequestDto product);
    Task<bool> DeleteProductAsync(int id);
}
