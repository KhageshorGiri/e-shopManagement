
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMgt.DAL.Entities;

public class BlogSubCategory : Base
{
    [Required]
    [StringLength(50, ErrorMessage = "SubCategory Name should  be less then 50 characters.")]
    public required string SubCategory { get; set; }

    [Required]
    [StringLength(150, ErrorMessage = "Description should  be less then 150 characters.")]
    public required string Description { get; set; }

    [ForeignKey(nameof(BlogCategory))]
    public int? CategoryID { get; set; }
    public BlogCategory? Category { get; set; }

    public IEnumerable<Blog>? Blogs { get; set; }
}
