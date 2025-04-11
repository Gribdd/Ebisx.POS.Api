using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ebisx.POS.Api.Entities;

/// <summary>
/// Represents a payment entity in the POS system.
/// </summary>
public class Payment
{
    /// <summary>
    /// Gets or sets the unique identifier for the payment.
    /// </summary>
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the amount paid.
    /// </summary>
    public decimal AmountPaid { get; set; }

    /// <summary>
    /// Gets or sets the payment type identifier.
    /// </summary>
    [Required]
    [ForeignKey("PaymentType")]
    public int PaymentTypeId { get; set; }

    /// <summary>
    /// Gets or sets the payment type.
    /// </summary>
    public PaymentType? PaymentType { get; set; }

    /// <summary>
    /// Gets or sets the order identifier.
    /// </summary>
    [Required]
    [ForeignKey("Order")]
    public int OrderId { get; set; }

    /// <summary>
    /// Gets or sets the non-cash payment method identifier. Optional for non-cash payments.
    /// </summary>
    [ForeignKey("NonCashPaymentMethod")]
    public int? NonCashPaymentMethodID { get; set; }

    /// <summary>
    /// Gets or sets the non-cash payment method.
    /// </summary>
    public NonCashPaymentMethod? NonCashPaymentMethod { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier. Optional if payment is not cash.
    /// </summary>
    [ForeignKey("Customer")]
    public int? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the customer.
    /// </summary>
    public Customer? Customer { get; set; }
}
