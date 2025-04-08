using Ebisx.POS.Api.DTOs.Discount;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IDiscountService
{
    Task<IEnumerable<DiscountRequestDto>> GetAllDiscountsAsync();
    Task<DiscountRequestDto?> GetDiscountByIdAsync(int id);
    Task<DiscountRequestDto> CreateDiscountAsync(DiscountRequestDto discount);
    Task<bool> UpdateDiscountAsync(int id, DiscountRequestDto discount);
    Task<bool> DeleteDiscountAsync(int id);
}
