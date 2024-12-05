using CMgt.DAL.Data;
using CMgt.DAL.Entities;
using CMgt.DAL.IRepositoriesl;
using Microsoft.EntityFrameworkCore;

namespace CMgt.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
   
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
    {
        return await  _dbContext.Categories
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Categories.Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddNewCatgory(Category category, CancellationToken cancellationToken = default)
    {
        using(var trainsaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _dbContext.Categories.Add(category);
                await _dbContext.SaveChangesAsync();
                trainsaction.Commit();
            }catch (Exception ex)
            {
                trainsaction.Rollback();
                throw;
            }
        }
    }

}
