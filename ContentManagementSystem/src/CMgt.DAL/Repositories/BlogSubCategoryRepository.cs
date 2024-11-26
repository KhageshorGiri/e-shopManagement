using CMgt.DAL.Data;
using CMgt.DAL.Entities;
using CMgt.DAL.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CMgt.DAL.Repositories;

public class BlogSubCategoryRepository : IBlogSubCategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    public BlogSubCategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<BlogSubCategory>> GetAllSubCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogSubCategories.AsNoTracking().ToListAsync();
    }

    public async Task<BlogSubCategory?> GetSubCategorYByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogSubCategories.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
    }

    public async Task AddNewSubCategoryAsync(BlogSubCategory blogSubCategory, CancellationToken cancellationToken = default)
    {
       using(var transaction = await _dbContext.Database.BeginTransactionAsync())
       {
            try
            {
                _dbContext.BlogSubCategories.Add(blogSubCategory);
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
