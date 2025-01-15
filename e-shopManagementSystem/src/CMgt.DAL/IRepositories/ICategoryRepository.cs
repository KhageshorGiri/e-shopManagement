using CMgt.Domain.Entities;

namespace CMgt.Domain.IRepositories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
    Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddNewCatgory(Category category, CancellationToken cancellationToken = default);

    Task DeleteCategory(Category category, CancellationToken cancellationToken = default);
}
