using Ebisx.POS.Api.DTOs.Payment;
using Ebisx.POS.Api.Entities;

namespace Ebisx.POS.Api.Services.Interfaces;

public interface IPaymentService
{
    Task<IEnumerable<PaymentResponseDto>> GetAllPaymentsAsync();
    Task<PaymentResponseDto?> GetPaymentByIdAsync(int id);
    Task<PaymentResponseDto> CreatePaymentAsync(PaymentRequestDto payment);
    Task<bool> UpdatePaymentAsync(int id, PaymentRequestDto payment);
    Task<bool> DeletePaymentAsync(int id);
}
