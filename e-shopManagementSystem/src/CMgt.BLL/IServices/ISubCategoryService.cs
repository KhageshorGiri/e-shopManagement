using CMgt.DAL.Entities;

namespace CMgt.BLL.IServices;

public interface ISubCategoryService
{
    Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default);
    Task<SubCategory?> GetSubCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddNewSubCategoryAsync(SubCategory blogSubCategory, CancellationToken cancellationToken = default);
}
