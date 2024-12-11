
using System.ComponentModel.DataAnnotations.Schema;

namespace CMgt.DAL.Entities;

public class Order : Base
{
    public DateTime OrderDate { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
