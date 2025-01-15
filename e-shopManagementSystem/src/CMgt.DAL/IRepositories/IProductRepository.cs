using CMgt.Domain.Entities;
using CMgt.shared.ViewModels;

namespace CMgt.Domain.IRepositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductViewModel>> GetAllProductsFilterAsync(string filter ,CancellationToken cancellationToken = default);
    Task<ProductViewModel> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Product> GetProductByIdAsync_(int id, CancellationToken cancellationToken = default);
    Task AddProductAsync(Product product, List<ProductImages> productImages, CancellationToken cancellationToken = default);
    Task UpdateProductAsync(Product product, CancellationToken cancellationToken = default);
    Task DeleteProductAsync(Product product, CancellationToken cancellationToken = default);
}
