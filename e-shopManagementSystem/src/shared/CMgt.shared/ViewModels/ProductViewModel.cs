

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CMgt.shared.ViewModels;

public class ProductViewModel
{
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
    public List<IFormFile> ImageFiles { get; set; } // For uploading images

    public List<ProductImageViewModel> Images { get; set; } = new();
}

// ViewModel for Images
public class ProductImageViewModel
{
    [Required]
    [StringLength(150)]
    public string ImagePath { get; set; }

    [Required]
    public int DisplayOrder { get; set; }
}
