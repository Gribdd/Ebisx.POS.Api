    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

namespace Ebisx.POS.Api.Entities;

public class Payment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public decimal AmountPaid { get; set; }

    [Required]
    [ForeignKey("PayomentType")]
    public int PaymentTypeId { get; set; }
    public PaymentType? PaymentType { get; set; }

    [Required]
    [ForeignKey("Order")]
    public int OrderId { get; set; }


    // optional for noncash payment
    [ForeignKey("NonCashPaymentMethod")]
    public int? NonCashPaymentMethodID { get; set; }
    public NonCashPaymentMethod? NonCashPaymentMethod { get; set; }

    //optional if payment is not cash
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
}
