using CMgt.DAL.Entities;

namespace CMgt.BLL.IServices;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllBlogCategoriesAsync(CancellationToken cancellationToken = default);
    Task<Category?> GetBlogCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddBlogCategoryAsync(Category blogCategory, CancellationToken cancellationToken = default);
}
