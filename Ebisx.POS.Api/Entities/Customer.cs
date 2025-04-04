    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace Ebisx.POS.Api.Entities;

public class Customer
    {
        //used for noncash payment and discount purposes
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? TinNumber { get; set; } 
        //for pwd or senior citizen discount
        public string? IdNumber { get; set; }
    }
