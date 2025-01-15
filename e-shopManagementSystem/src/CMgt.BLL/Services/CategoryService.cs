using CMgt.Application.IServices;
using CMgt.Domain.Entities;
using CMgt.Domain.IRepositories;

namespace CMgt.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _blogCategoryRepository;
    public CategoryService(ICategoryRepository blogCategoryRepository)
    {
        _blogCategoryRepository = blogCategoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _blogCategoryRepository.GetAllCategoriesAsync(cancellationToken);
    }

    public async Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _blogCategoryRepository.GetCategoryByIdAsync(id, cancellationToken);
    }

    public async Task AddCategoryAsync(Category blogCategory, CancellationToken cancellationToken = default)
    {
        blogCategory.CreatedBy = 1;
        blogCategory.ModifiedBy = 1;
        blogCategory.CreatedDate = DateTime.UtcNow;
        blogCategory.ModifiedDate = DateTime.UtcNow;

        await _blogCategoryRepository.AddNewCatgory(blogCategory, cancellationToken);
    }

    public async Task DeleteCategory(int id, CancellationToken cancellationToken = default)
    {
        var existing = await _blogCategoryRepository.GetCategoryByIdAsync(id);
        if (existing != null)
        {
            await _blogCategoryRepository.DeleteCategory(existing);
        }
    }
}
