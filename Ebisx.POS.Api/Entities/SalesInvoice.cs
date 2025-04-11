using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Ebisx.POS.Api.Entities;
/// <summary>
/// Represents a sales invoice in the POS system.
/// </summary>
[Index(nameof(PublicId), IsUnique = true)]
public class SalesInvoice
{
    /// <summary>
    /// Gets or sets the private identifier for the sales invoice.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PrivateId { get; set; }

    /// <summary>
    /// Gets or sets the public identifier for the sales invoice.
    /// </summary>
    public string PublicId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the collection of payments associated with the sales invoice.
    /// </summary>
    public ICollection<Payment>? Payments { get; set; }

    /// <summary>
    /// Gets or sets the order identifier associated with the sales invoice.
    /// </summary>
    [ForeignKey("Order")]
    public int OrderId { get; set; }

    /// <summary>
    /// Gets or sets the order associated with the sales invoice.
    /// </summary>
    public Order? Order { get; set; }

    /// <summary>
    /// Gets or sets the machine information identifier associated with the sales invoice.
    /// </summary>
    [ForeignKey("MachineInfo")]
    public int MachineInfoId { get; set; }

    /// <summary>
    /// Gets or sets the machine information associated with the sales invoice.
    /// </summary>
    public MachineInfo? MachineInfo { get; set; }

    /// <summary>
    /// Gets or sets the business information identifier associated with the sales invoice.
    /// </summary>
    [ForeignKey("BusinessInfo")]
    public int BusinessInfoId { get; set; }

    /// <summary>
    /// Gets or sets the business information associated with the sales invoice.
    /// </summary>
    public BusinessInfo? BusinessInfo { get; set; }

    /// <summary>
    /// Gets or sets the user identifier associated with the sales invoice.
    /// </summary>
    [ForeignKey("User")]
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the sales invoice.
    /// </summary>
    public User? User { get; set; }

    public ICollection<Payment> Payment { get; set; } = null!;
}
