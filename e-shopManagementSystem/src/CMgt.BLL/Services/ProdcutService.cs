
using CMgt.BLL.IServices;
using CMgt.DAL.Entities;
using CMgt.DAL.Entities.Enums;
using CMgt.DAL.IRepositories;
using CMgt.shared.Helpers;
using CMgt.shared.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Drawing;

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
            SubCategoryId = product.SubCategoryId
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

    public async Task<IEnumerable<ProductViewModel>> GetAllProductsFilterAsync(string filter, CancellationToken cancellationToken = default)
    {
        return await _productRepository.GetAllProductsFilterAsync(filter);
    }

    public async Task<ProductViewModel> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _productRepository.GetProductByIdAsync(id, cancellationToken);
    }


    public async Task DeleteProductAsync(int id, CancellationToken cancellationToken = default)
    {
        var existingProdcut = await _productRepository.GetProductByIdAsync_(id);

        if (existingProdcut != null)
        {
            await _productRepository.DeleteProductAsync(existingProdcut);
        }

    }

    public async Task UpdateProductAsync(ProductViewModel product, CancellationToken cancellationToken = default)
    {
        var productToUpdate = await _productRepository.GetProductByIdAsync_(product.Id);

        if(productToUpdate != null)
        {
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.Price = product.Price;
            productToUpdate.StockQuantity = product.StockQuantity;
            productToUpdate.Size = (ProductSize)product.Size;
            productToUpdate.Brand = product.Brand;
            productToUpdate.Description = product.Description;
            if(product.SubCategoryId != 0 || product.SubCategoryId > 0)
            {
                productToUpdate.SubCategoryId = product.SubCategoryId;
            }

            await _productRepository.UpdateProductAsync(productToUpdate);
        }

       
    }
}
