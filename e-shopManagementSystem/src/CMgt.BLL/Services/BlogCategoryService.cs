using CMgt.BLL.IServices;
using CMgt.DAL.Entities;
using CMgt.DAL.IRepositoriesl;

namespace CMgt.BLL.Services;

public class BlogCategoryService : IBlogCategoryService
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;
    public BlogCategoryService(IBlogCategoryRepository blogCategoryRepository)
    {
        _blogCategoryRepository = blogCategoryRepository;
    }

    public async Task<IEnumerable<BlogCategory>> GetAllBlogCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _blogCategoryRepository.GetAllBlogCategoriesAsync(cancellationToken);
    }

    public async Task<BlogCategory?> GetBlogCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _blogCategoryRepository.GetBlogCategoryByIdAsync(id, cancellationToken);
    }


    public async Task AddBlogCategoryAsync(BlogCategory blogCategory, CancellationToken cancellationToken = default)
    {
        blogCategory.CreatedBy = 1;
        blogCategory.ModifiedBy = 1;
        blogCategory.CreatedDate = DateTime.UtcNow;
        blogCategory.ModifiedDate = DateTime.UtcNow;

        await _blogCategoryRepository.AddNewBlogCatgory(blogCategory, cancellationToken);
    }
}
