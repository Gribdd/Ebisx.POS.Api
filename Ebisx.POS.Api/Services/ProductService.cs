using AutoMapper;
using Ebisx.POS.Api.Data;
using Ebisx.POS.Api.DTOs.Product;
using Ebisx.POS.Api.Entities;
using Ebisx.POS.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Ebisx.POS.Api.Services;

/// <summary>
/// Service for managing product-related operations in the POS system.
/// </summary>
public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<ProductService> _logger;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductService"/> class.
    /// </summary>
    /// <param name="dbContext">The database context for accessing product data.</param>
    /// <param name="logger">The logger for logging errors and information.</param>
    /// <param name="mapper">The mapper for mapping entities to DTOs and vice versa.</param>
    public ProductService(
        ApplicationDbContext dbContext,
        ILogger<ProductService> logger,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// Retrieves all products from the database.
    /// </summary>
    /// <returns>A collection of <see cref="ProductResponseDto"/> representing all products.</returns>
    public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
    {
        try
        {
            var products = await _dbContext.Products.ToListAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductResponseDto>>(products);
            return productDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occurred while fetching all products: {Message}", ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <returns>A <see cref="ProductResponseDto"/> representing the product, or null if not found.</returns>
    public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
    {
        try
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return null;
            var productDto = _mapper.Map<ProductResponseDto>(product);
            return productDto;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occurred while fetching product with ID {Id}: {Message}", id, ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Creates a new product in the database.
    /// </summary>
    /// <param name="product">The product data to create.</param>
    /// <returns>A <see cref="ProductResponseDto"/> representing the created product.</returns>
    public async Task<ProductResponseDto> CreateProductAsync(ProductRequestDto product)
    {
        try
        {
            var productEntity = _mapper.Map<Product>(product);
            _dbContext.Products.Add(productEntity);
            await _dbContext.SaveChangesAsync();

            var productResponseDto = _mapper.Map<ProductResponseDto>(productEntity);
            return productResponseDto;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occurred while creating a product: {Message}", ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Updates an existing product in the database.
    /// </summary>
    /// <param name="id">The unique identifier of the product to update.</param>
    /// <param name="updatedProductDto">The updated product data.</param>
    /// <returns>True if the update was successful, false if the product was not found.</returns>
    public async Task<bool> UpdateProductAsync(int id, ProductRequestDto updatedProductDto)
    {
        try
        {
            var existingProduct = await _dbContext.Products.FindAsync(id);
            if (existingProduct == null)
                return false;

            _mapper.Map(updatedProductDto, existingProduct);    
            _dbContext.Products.Attach(existingProduct);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occurred while updating product with ID {Id}: {Message}", id, ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Deletes a product from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete.</param>
    /// <returns>True if the deletion was successful, false if the product was not found.</returns>
    public async Task<bool> DeleteProductAsync(int id)
    {
        try
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null) return false;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error occurred while deleting product with ID {Id}: {Message}", id, ex.Message);
            throw;
        }
    }
}
