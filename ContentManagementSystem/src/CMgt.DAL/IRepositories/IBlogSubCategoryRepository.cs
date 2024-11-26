using CMgt.DAL.Entities;

namespace CMgt.DAL.IRepositories;

public interface IBlogSubCategoryRepository
{
    Task<IEnumerable<BlogSubCategory>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default);
    Task<BlogSubCategory?> GetSubCategorYByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddNewSubCategoryAsync(BlogSubCategory blogSubCategory, CancellationToken cancellationToken = default);
}
