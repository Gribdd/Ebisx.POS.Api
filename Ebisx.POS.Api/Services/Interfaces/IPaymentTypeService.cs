using Ebisx.POS.Api.DTOs.PaymentType;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IPaymentTypeService
{
    Task<IEnumerable<PaymentTypeResponseDto>> GetAllPaymentTypesAsync();
    Task<PaymentTypeResponseDto?> GetPaymentTypeByIdAsync(int id);
    Task<PaymentTypeResponseDto> CreatePaymentTypeAsync(PaymentTypeRequestDto paymentType);
    Task<bool> UpdatePaymentTypeAsync(int id, PaymentTypeRequestDto paymentType);
    Task<bool> DeletePaymentTypeAsync(int id);
}
