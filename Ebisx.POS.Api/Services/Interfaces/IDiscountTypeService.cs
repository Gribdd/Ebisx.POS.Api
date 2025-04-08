using Ebisx.POS.Api.DTOs.DiscountType;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IDiscountTypeService
{
    Task<IEnumerable<DiscountTypeResponseDto>> GetAllDiscountTypesAsync();
    Task<DiscountTypeResponseDto?> GetDiscountTypeByIdAsync(int id);
    Task<DiscountTypeResponseDto> CreateDiscountTypeAsync(DiscountTypeRequestDto discountType);
    Task<bool> UpdateDiscountTypeAsync(int id, DiscountTypeRequestDto discountType);
    Task<bool> DeleteDiscountTypeAsync(int id);
}
