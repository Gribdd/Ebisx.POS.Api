namespace Ebisx.POS.Api.DTOs.SalesInvoice;

// SalesInvoice DTOs
public class SalesInvoiceRequestDto
{
    public string PublicId { get; set; } = string.Empty;
    public int OrderId { get; set; }
    public int MachineInfoId { get; set; }
    public int BusinessInfoId { get; set; }
    public int UserId { get; set; }
}
