using CMgt.BLL.IServices;
using CMgt.DAL.Entities;
using CMgt.DAL.IRepositories;

namespace CMgt.BLL.Services;

public class BlogSubCategoryService : IBlogSubCategoryService
{
    private readonly IBlogSubCategoryRepository _blogSubCategoryRepository;
    public BlogSubCategoryService(IBlogSubCategoryRepository blogSubCategoryRepository)
    {
        _blogSubCategoryRepository = blogSubCategoryRepository;
    }
  
    public async Task<IEnumerable<BlogSubCategory>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _blogSubCategoryRepository.GetAllSubCategoriesAsync();
    }

    public async Task<BlogSubCategory?> GetSubCategorYByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _blogSubCategoryRepository.GetSubCategorYByIdAsync(id);
    }

    public async Task AddNewSubCategoryAsync(BlogSubCategory blogSubCategory, CancellationToken cancellationToken = default)
    {
        blogSubCategory.CreatedBy = 1;
        blogSubCategory.ModifiedBy = 1;
        blogSubCategory.CreatedDate = DateTime.UtcNow;
        blogSubCategory.ModifiedDate = DateTime.UtcNow;
        await _blogSubCategoryRepository.AddNewSubCategoryAsync(blogSubCategory);
    }

}
