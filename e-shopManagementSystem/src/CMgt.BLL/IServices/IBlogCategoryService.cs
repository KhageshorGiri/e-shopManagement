using CMgt.DAL.Entities;

namespace CMgt.BLL.IServices;

public interface IBlogCategoryService
{
    Task<IEnumerable<BlogCategory>> GetAllBlogCategoriesAsync(CancellationToken cancellationToken = default);
    Task<BlogCategory?> GetBlogCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddBlogCategoryAsync(BlogCategory blogCategory, CancellationToken cancellationToken = default);
}
