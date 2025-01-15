
using CMgt.Domain.Entities;

namespace CMgt.Application.IServices;

public interface ISubCategoryService
{
    Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default);
    Task<SubCategory?> GetSubCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddNewSubCategoryAsync(SubCategory blogSubCategory, CancellationToken cancellationToken = default);
    Task DeleteSubCategory(int id, CancellationToken cancellationToken = default);
}
