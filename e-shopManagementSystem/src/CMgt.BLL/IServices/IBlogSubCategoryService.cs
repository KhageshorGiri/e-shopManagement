using CMgt.DAL.Entities;

namespace CMgt.BLL.IServices;

public interface IBlogSubCategoryService
{
    Task<IEnumerable<BlogSubCategory>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default);
    Task<BlogSubCategory?> GetSubCategorYByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddNewSubCategoryAsync(BlogSubCategory blogSubCategory, CancellationToken cancellationToken = default);
}
