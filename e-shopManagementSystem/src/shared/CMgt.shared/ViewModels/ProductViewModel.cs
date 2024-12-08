
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CMgt.shared.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    [Required]
    [StringLength(150)]
    public string ProductName { get; set; }

    [Required]
    public int Size { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int StockQuantity { get; set; }

    [Required]
    [StringLength(50)]
    public string Brand { get; set; }
    
    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int SubCategoryId { get; set; }

    [Required]
    [StringLength(350)]
    public string Description { get; set; }

    // Image Properties
    public string? ImageLocation { get; set; } = string.Empty;
    public IFormFile ImagesFile { get; set; }

    public int DisplayOrder { get; set; }
}

// ViewModel for Images
public class ProductImageViewModel
{
    [Required]
    [StringLength(150)]
    public IFormFile ImagePath { get; set; }

    [Required]
    public int DisplayOrder { get; set; }

    public string ImageLocation { get; set; }
}
