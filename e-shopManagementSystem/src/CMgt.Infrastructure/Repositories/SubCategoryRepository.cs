using CMgt.Domain.Entities;
using CMgt.Domain.IRepositories;
using CMgt.Infrastrucutre.Data;
using Microsoft.EntityFrameworkCore;

namespace CMgt.Infrastrucutre.Repositories;

public class SubCategoryRepository : ISubCategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    public SubCategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SubCategories.AsNoTracking().ToListAsync();
    }

    public async Task<SubCategory?> GetSubCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.SubCategories.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task AddNewSubCategoryAsync(SubCategory blogSubCategory, CancellationToken cancellationToken = default)
    {
       using(var transaction = await _dbContext.Database.BeginTransactionAsync())
       {
            try
            {
                _dbContext.SubCategories.Add(blogSubCategory);
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
            }catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
       }
    }

    public async Task DeleteSubCategory(SubCategory blogSubCategory, CancellationToken cancellationToken = default)
    {
        _dbContext.SubCategories.Remove(blogSubCategory);
        await _dbContext.SaveChangesAsync();
    }
}
