
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ebisx.POS.Api.Entities;

public class Order 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]   
    public int Id { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public string Status { get; set; } = string.Empty;
}
