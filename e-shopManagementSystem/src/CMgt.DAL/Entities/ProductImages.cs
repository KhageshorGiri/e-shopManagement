using CMgt.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMgt.Domain.Entities;

public class ProductImages : Base
{
    [Required]
    [StringLength(150)]
    public required string ImagePath { get; set; }

    [Required]
    [EnumDataType(typeof(DisplayOrder))]
    public DisplayOrder DisplayOrder { get; set; }

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
