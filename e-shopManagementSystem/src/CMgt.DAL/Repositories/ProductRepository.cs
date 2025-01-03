using CMgt.DAL.Data;
using CMgt.DAL.Entities;
using CMgt.DAL.IRepositories;
using CMgt.shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CMgt.DAL.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddProductAsync(Product product, List<ProductImages> productImages, CancellationToken cancellationToken = default)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync(cancellationToken);

                foreach(var image in productImages)
                {
                    image.ProductId = product.Id;
                }

                await _dbContext.ProductImages.AddRangeAsync(productImages);
                await _dbContext.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(CancellationToken cancellationToken = default)
    {
        var allProducts = await _dbContext.Products.Include(p => p.Images)
             .Select(p => new ProductViewModel
             {
                 Id = p.Id,
                 ProductName = p.ProductName,
                 Price = p.Price,
                 StockQuantity = p.StockQuantity,
                 Size = Convert.ToInt32(p.Size),
                 Brand = p.Brand,
                 Description = p.Description,
                 ImageLocation = p.Images.FirstOrDefault().ImagePath
             }).AsNoTracking()
             .ToListAsync(cancellationToken);

        return allProducts;
    }

    public async Task<IEnumerable<ProductViewModel>> GetAllProductsFilterAsync(string filter, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter))
        {
            query = query.Where(p => p.ProductName.Contains(filter));
        }

        var allProducts = await query
            .Include(p => p.Images)
             .Select(p => new ProductViewModel
             {
                 Id = p.Id,
                 ProductName = p.ProductName,
                 Price = p.Price,
                 StockQuantity = p.StockQuantity,
                 Size = Convert.ToInt32(p.Size),
                 Brand = p.Brand,
                 Description = p.Description,
                 ImageLocation = p.Images.FirstOrDefault().ImagePath
             }).AsNoTracking()
             .ToListAsync(cancellationToken);

        return allProducts;
    }

    public async Task<ProductViewModel> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var productDetails = await _dbContext.Products.Where(p=>p.Id == id)
            .Include(p => p.Images)
              .Select(p => new ProductViewModel
              {
                  Id = p.Id,
                  ProductName = p.ProductName,
                  Price = p.Price,
                  StockQuantity = p.StockQuantity,
                  Size = Convert.ToInt32(p.Size),
                  Brand = p.Brand,
                  Description = p.Description,
                  ImageLocation = p.Images.FirstOrDefault().ImagePath
              }).AsNoTracking()
              .FirstOrDefaultAsync(cancellationToken);

        return productDetails;
    }
}
