using CMgt.DAL.Entities;

namespace CMgt.DAL.IRepositories;

public interface ISubCategoryRepository
{
    Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default);
    Task<SubCategory?> GetSubCategoryByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddNewSubCategoryAsync(SubCategory blogSubCategory, CancellationToken cancellationToken = default);
    Task DeleteSubCategory(SubCategory blogSubCategory, CancellationToken cancellationToken = default);
}
