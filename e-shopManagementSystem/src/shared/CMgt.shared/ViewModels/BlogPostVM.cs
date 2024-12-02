using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CMgt.shared.ViewModels;

public class BlogPostVM
{
    public DateTime Date { get; set; }

    public string? Image { get; set; } // Path or string representation of the image
    public IFormFile? ImageFile { get; set; } // For file upload

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Category is required")]
    public int CategoryID { get; set; }

    public string? ShortDescription { get; set; }

    public string? Description { get; set; }
}
