using Ebisx.POS.Api.DTOs.NonCashPaymentMethod;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface INonCashPaymentMethodService
{
    Task<IEnumerable<NonCashPaymentMethodResponseDto>> GetAllNonCashPaymentMethodsAsync();
    Task<NonCashPaymentMethodResponseDto?> GetNonCashPaymentMethodByIdAsync(int id);
    Task<NonCashPaymentMethodResponseDto> CreateNonCashPaymentMethodAsync(NonCashPaymentMethodRequestDto nonCashPaymentMethod);
    Task<bool> UpdateNonCashPaymentMethodAsync(int id, NonCashPaymentMethodRequestDto nonCashPaymentMethod);
    Task<bool> DeleteNonCashPaymentMethodAsync(int id);
}
