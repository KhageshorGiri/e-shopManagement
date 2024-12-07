
using CMgt.BLL.IServices;
using CMgt.DAL.Entities;
using CMgt.DAL.Entities.Enums;
using CMgt.DAL.IRepositories;
using CMgt.shared.ViewModels;

namespace CMgt.BLL.Services;

public class ProdcutService : IProdcutService
{
    private readonly IProductRepository _productRepository;
    public ProdcutService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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
        foreach(var image in product.Images)
        {
            images.Add(new() { ImagePath = image.ImagePath, DisplayOrder = (DisplayOrder)image.DisplayOrder });
        }

        await _productRepository.AddProductAsync(newProduct, images);
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(CancellationToken cancellationToken = default)
    {
        return await _productRepository.GetAllProductsAsync(cancellationToken);
    }
}
