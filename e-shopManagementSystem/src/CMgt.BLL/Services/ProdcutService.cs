
using CMgt.BLL.IServices;
using CMgt.DAL.Entities;
using CMgt.DAL.Entities.Enums;
using CMgt.DAL.IRepositories;
using CMgt.shared.Helpers;
using CMgt.shared.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace CMgt.BLL.Services;

public class ProdcutService : IProdcutService
{
    private readonly IProductRepository _productRepository;
    private readonly IWebHostEnvironment _env;
    public ProdcutService(IProductRepository productRepository, IWebHostEnvironment evn)
    {
        _productRepository = productRepository;
        _env = evn;
    }
    public async Task AddProductAsync(ProductViewModel product, CancellationToken cancellationToken = default)
    {
        // Creating seperate object for each table
        Product newProduct = new() {
            ProductName = product.ProductName,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            Size = (ProductSize)product.Size,
            Brand = product.Brand,
            Description = product.Description,
        };

        List<ProductImages> images = new List<ProductImages>();
        var webRootPath = _env.WebRootPath;
        var imageLocation = SaveImage.SaveFile(webRootPath, "ProductImages", product.ImagesFile);
        images.Add(new ProductImages
        {
            ImagePath = imageLocation,
            DisplayOrder = (DisplayOrder)product.DisplayOrder
        });
        
        await _productRepository.AddProductAsync(newProduct, images);
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(CancellationToken cancellationToken = default)
    {
        return await _productRepository.GetAllProductsAsync(cancellationToken);
    }

    public async Task<ProductViewModel> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _productRepository.GetProductByIdAsync(id, cancellationToken);
    }
}
