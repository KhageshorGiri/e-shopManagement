using CMgt.DAL.Entities;

namespace CMgt.DAL.IRepositories;

public interface ISubCategoryRepository
{
    Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default);
    Task<SubCategory?> GetSubCategorYByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddNewSubCategoryAsync(SubCategory blogSubCategory, CancellationToken cancellationToken = default);
}
