using CMgt.DAL.Entities;

namespace CMgt.DAL.IRepositoriesl;

public interface IBlogCategoryRepository
{
    Task<IEnumerable<BlogCategory>> GetAllBlogCategoriesAsync(CancellationToken cancellationToken = default);
    Task<BlogCategory?> GetBlogCategoryByIdAsync(int id, CancellationToken cancellationToken = default);

    Task AddNewBlogCatgory(BlogCategory category, CancellationToken cancellationToken = default);
}
