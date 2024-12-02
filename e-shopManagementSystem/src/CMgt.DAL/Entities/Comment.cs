


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMgt.DAL.Entities;

public class Comment : Base
{
    [Required]
    [StringLength(maximumLength:200)]
    public required string Message { get; set; }

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
