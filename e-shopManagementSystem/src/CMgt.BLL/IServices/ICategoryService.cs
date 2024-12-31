using CMgt.DAL.Entities;

namespace CMgt.BLL.IServices;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
    Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddCategoryAsync(Category blogCategory, CancellationToken cancellationToken = default);
    Task DeleteCategory(int id, CancellationToken cancellationToken = default);
}
