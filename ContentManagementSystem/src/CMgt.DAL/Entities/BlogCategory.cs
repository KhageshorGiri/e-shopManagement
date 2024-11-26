using System.ComponentModel.DataAnnotations;

namespace CMgt.DAL.Entities;

public class BlogCategory : Base
{
    [Required]
    [StringLength(50, ErrorMessage = "Category Name should  be less then 50 characters.")]
    public required string Category { get; set; }

    [Required]
    [StringLength(150, ErrorMessage = "Description Name should  be less then 150 characters.")]
    public required string Description { get; set; }

    public IEnumerable<BlogSubCategory>? SubCategories { get; set; }
}
