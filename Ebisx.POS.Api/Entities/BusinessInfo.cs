using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ebisx.POS.Api.Entities;

public class BusinessInfo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string RegistedName { get; set; } = string.Empty;
    [Required]
    public string Address { get; set; } = string.Empty;
    [Required]
    public string VatTinNumber { get; set; } = string.Empty;
}

public class MachineInfo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string PosSerialNumber { get; set; } = string.Empty;
    [Required]
    public string MinNumber { get; set; } = string.Empty;   
    [Required]
    public string AccreditationNumber { get; set; } = string.Empty;
    [Required]
    public string PtuNumber { get; set; } = string.Empty;
    [Required]
    public DateTime DateIssued { get; set; }
    [Required]
    public DateTime ValidUntil { get; set; }
}

public class PaymentType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}

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
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }

    // optional for noncash payment
    [ForeignKey("NonCashPaymentMethod")]
    public int? NonCashPaymentMethodID { get; set; }
    public NonCashPaymentMethod? NonCashPaymentMethod { get; set; }
}

public class NonCashPaymentMethod
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Provider { get; set; } = string.Empty;
}

public class Customer
{
    //used for noncash payment and discount purposes
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]  
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    public string? TinNumber { get; set; }
    //for pwd or senior citizen discount
    public string? IdNumber { get; set; }
}

public class Discount
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Value { get; set; } = string.Empty;
    [Required]
    public bool IsPercentage { get; set; }

    [Required]
    [ForeignKey("DiscountType")]
    public int DiscountTypeId { get; set; }
    public DiscountType? DiscountType { get; set; }

}

public class DiscountType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}
