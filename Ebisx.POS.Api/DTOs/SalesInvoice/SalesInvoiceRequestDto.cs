using Ebisx.POS.Api.DTOs.Payment;

namespace Ebisx.POS.Api.DTOs.SalesInvoice;

// SalesInvoice DTOs
public class SalesInvoiceRequestDto
{
    public int OrderId { get; set; }
    public int MachineInfoId { get; set; }
    public int BusinessInfoId { get; set; }
    public ICollection<PaymentResponseDto>? Payments { get; set; }
    public int UserId { get; set; }
}
