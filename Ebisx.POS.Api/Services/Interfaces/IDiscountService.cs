using Ebisx.POS.Api.DTOs.Discount;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IDiscountService
{
    Task<IEnumerable<DiscountResponseDto>> GetAllDiscountsAsync();
    Task<DiscountResponseDto?> GetDiscountByIdAsync(int id);
    Task<DiscountResponseDto> CreateDiscountAsync(DiscountRequestDto discount);
    Task<bool> UpdateDiscountAsync(int id, DiscountRequestDto discount);
    Task<bool> DeleteDiscountAsync(int id);
}
