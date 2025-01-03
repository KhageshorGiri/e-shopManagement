
using CMgt.DAL.Entities;
using CMgt.shared.ViewModels;

namespace CMgt.BLL.IServices;

public interface IProdcutService
{
    Task<IEnumerable<ProductViewModel>> GetAllProductsAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductViewModel>> GetAllProductsFilterAsync(string filter, CancellationToken cancellationToken = default);
    Task<ProductViewModel> GetProductByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddProductAsync(ProductViewModel product, CancellationToken cancellationToken = default);
    Task UpdateProductAsync(ProductViewModel product, CancellationToken cancellationToken = default);
    Task DeleteProductAsync(int id, CancellationToken cancellationToken = default);
}
