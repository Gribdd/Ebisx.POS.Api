    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace Ebisx.POS.Api.Entities;

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
