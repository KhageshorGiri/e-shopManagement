using CMgt.DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace CMgt.DAL.Entities;

public class Product : Base
{
    [Required]
    [StringLength(150)]
    public string ProductName { get; set; }
    [Required]
    [EnumDataType(typeof(ProductSize))]
    public ProductSize Size { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int StockQuantity { get; set; }
    [Required]
    [StringLength(50)]
    public string Brand { get; set; }
    [Required]
    [StringLength(350)]
    public string Description { get; set; }

    // Relationship management
    public ICollection<Comment> Comments { get; set; }
    public ICollection<ProductImages> Images { get; set; }
}
