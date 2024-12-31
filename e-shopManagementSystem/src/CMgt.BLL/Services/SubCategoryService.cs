using CMgt.BLL.IServices;
using CMgt.DAL.Entities;
using CMgt.DAL.IRepositories;

namespace CMgt.BLL.Services;

public class SubCategoryService : ISubCategoryService
{
    private readonly ISubCategoryRepository _blogSubCategoryRepository;
    public SubCategoryService(ISubCategoryRepository blogSubCategoryRepository)
    {
        _blogSubCategoryRepository = blogSubCategoryRepository;
    }
  
    public async Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _blogSubCategoryRepository.GetAllSubCategoriesAsync();
    }

    public async Task<SubCategory?> GetSubCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _blogSubCategoryRepository.GetSubCategoryByIdAsync(id);
    }

    public async Task AddNewSubCategoryAsync(SubCategory blogSubCategory, CancellationToken cancellationToken = default)
    {
        blogSubCategory.CreatedBy = 1;
        blogSubCategory.ModifiedBy = 1;
        blogSubCategory.CreatedDate = DateTime.UtcNow;
        blogSubCategory.ModifiedDate = DateTime.UtcNow;
        await _blogSubCategoryRepository.AddNewSubCategoryAsync(blogSubCategory);
    }

    public async Task DeleteSubCategory(int id, CancellationToken cancellationToken = default)
    {
        var existing = await _blogSubCategoryRepository.GetSubCategoryByIdAsync(id);
        if (existing != null){
            await _blogSubCategoryRepository.DeleteSubCategory(existing);
        }
    }
}
