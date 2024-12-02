using CMgt.DAL.Data;
using CMgt.DAL.Entities;
using CMgt.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CMgt.DAL.Repositories;

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

    public async Task<SubCategory?> GetSubCategorYByIdAsync(int id, CancellationToken cancellationToken = default)
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

}
