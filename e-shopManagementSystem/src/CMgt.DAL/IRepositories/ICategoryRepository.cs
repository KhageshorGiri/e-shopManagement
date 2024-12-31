using CMgt.DAL.Entities;

namespace CMgt.DAL.IRepositoriesl;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
    Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddNewCatgory(Category category, CancellationToken cancellationToken = default);

    Task DeleteCategory(Category category, CancellationToken cancellationToken = default);
}
