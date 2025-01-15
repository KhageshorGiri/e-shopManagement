using System.ComponentModel.DataAnnotations;

namespace CMgt.Domain.Entities;

public class Category : Base
{
    [Required]
    [StringLength(50, ErrorMessage = "Category Name should  be less then 50 characters.")]
    public required string CategoryName { get; set; }

    [Required]
    [StringLength(150, ErrorMessage = "Description Name should  be less then 150 characters.")]
    public required string Description { get; set; }

    public IEnumerable<SubCategory>? SubCategories { get; set; }
}
