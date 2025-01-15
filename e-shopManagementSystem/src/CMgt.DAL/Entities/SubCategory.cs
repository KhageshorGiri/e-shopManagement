
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMgt.Domain.Entities;

public class SubCategory : Base
{
    [Required]
    [StringLength(50, ErrorMessage = "SubCategory Name should  be less then 50 characters.")]
    public required string SubCategoryName { get; set; }

    [Required]
    [StringLength(150, ErrorMessage = "Description should  be less then 150 characters.")]
    public required string Description { get; set; }

    [ForeignKey(nameof(Entities.Category))]
    public int CategoryID { get; set; }
    public Category? Category { get; set; }

    public IEnumerable<Product>? Products { get; set; }
}
