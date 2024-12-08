using CMgt.DAL.Entities;
using CMgt.shared.ViewModels;

namespace CMgt.DAL.IRepositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(CancellationToken cancellationToken = default);
    Task<ProductViewModel> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddProductAsync(Product product, List<ProductImages> productImages, CancellationToken cancellationToken = default);
}
