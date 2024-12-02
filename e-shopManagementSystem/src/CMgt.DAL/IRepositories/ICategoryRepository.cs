using CMgt.DAL.Entities;

namespace CMgt.DAL.IRepositoriesl;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllBlogCategoriesAsync(CancellationToken cancellationToken = default);
    Task<Category?> GetBlogCategoryByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddNewBlogCatgory(Category category, CancellationToken cancellationToken = default);
}
