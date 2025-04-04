using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Ebisx.POS.Api.Entities;
[Index(nameof(PublicId), IsUnique = true)]

public class SalesInvoice
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int PrivateId { get; set; }

    public string PublicId { get; set; } = string.Empty;
    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public ICollection<Payment>? Payments { get; set; }

    [ForeignKey("MachineInfo")]
    public int MachineInfoId { get; set; }
    public MachineInfo? MachineInfo { get; set; }

    [ForeignKey("BusinessInfo")]
    public int BusinessInfoId { get; set; }
    public BusinessInfo? BusinessInfo { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }

}
