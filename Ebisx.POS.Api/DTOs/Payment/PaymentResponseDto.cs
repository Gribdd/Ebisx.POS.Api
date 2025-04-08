using Ebisx.POS.Api.DTOs.Customer;
using Ebisx.POS.Api.DTOs.NonCashPaymentMethod;
using Ebisx.POS.Api.DTOs.PaymentType;

namespace Ebisx.POS.Api.DTOs.Payment;

public class PaymentResponseDto
{
    public int Id { get; set; }
    public decimal AmountPaid { get; set; }
    public PaymentTypeResponseDto? PaymentType { get; set; }
    public int OrderId { get; set; }
    public NonCashPaymentMethodResponseDto? NonCashPaymentMethod { get; set; }
    public CustomerResponseDto? Customer { get; set; }
}
