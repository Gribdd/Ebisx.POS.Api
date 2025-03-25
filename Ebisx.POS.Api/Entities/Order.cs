
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ebisx.POS.Api.Entities;

public class Order : IBaseEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]   
    public Guid Id { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

}
