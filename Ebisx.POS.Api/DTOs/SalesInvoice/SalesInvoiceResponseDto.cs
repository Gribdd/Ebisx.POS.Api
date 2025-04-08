using Ebisx.POS.Api.DTOs.BusinessInfo;
using Ebisx.POS.Api.DTOs.MachineInfo;
using Ebisx.POS.Api.DTOs.Order;
using Ebisx.POS.Api.DTOs.Payment;
using Ebisx.POS.Api.DTOs.User;

namespace Ebisx.POS.Api.DTOs.SalesInvoice;

public class SalesInvoiceResponseDto
{
    public int PrivateId { get; set; }
    public string PublicId { get; set; } = string.Empty;
    public ICollection<PaymentResponseDto>? Payments { get; set; }
    public OrderResponseDto? Order { get; set; }
    public MachineInfoResponseDto? MachineInfo { get; set; }
    public BusinessInfoResponseDto? BusinessInfo { get; set; }
    public UserResponseDto? User { get; set; }
}
