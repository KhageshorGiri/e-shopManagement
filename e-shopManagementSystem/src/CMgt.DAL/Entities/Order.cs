using CMgt.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMgt.Domain.Entities;

public class Order : Base
{
    public DateTime OrderDate { get; set; }
    [Required]
    public int Quantity { get; set; }

    [EnumDataType(typeof(OrderStatus))]
    public OrderStatus Status { get; set; }

    //[ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
