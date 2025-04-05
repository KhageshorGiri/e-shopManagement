using System.ComponentModel.DataAnnotations;

namespace eshop.Customer.Core.Entity;
public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime LastModifiedDate { get; set; }
    public int? LastModifiedBy { get; set; }
}
