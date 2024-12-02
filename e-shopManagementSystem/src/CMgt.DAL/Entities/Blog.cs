using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMgt.DAL.Entities;

public class Blog : Base
{
    [Required(ErrorMessage = "Please Provide Blog Title.")]
    [StringLength(200)]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Please Provide Blog Date.")]
    [DataType(DataType.DateTime)]
    public required DateTime Date { get; set; }

    [Required(ErrorMessage = "Please Provide Short Introduction.")]
    [StringLength(800)]
    public required string ShortDescription { get; set; }

    [Required(ErrorMessage = "Please Provide Blog Description.")]
    public required string Description { get; set; }

    [Required(ErrorMessage = "Please Provide Image.")]
    [StringLength(500)]
    public required string Image { get; set; }

    [ForeignKey(nameof(BlogSubCategory))]
    public int? SubCategoryId { get; set; }
    public BlogSubCategory? SubCategory { get; set; }

    public IEnumerable<Comment> Comments { get; set; }

}
