using CMgt.DAL.Data;
using CMgt.DAL.Entities;
using CMgt.DAL.IRepositoriesl;
using Microsoft.EntityFrameworkCore;

namespace CMgt.DAL.Repositories;

public class BlogCategoryRepository : IBlogCategoryRepository
{
    private readonly ApplicationDbContext _dbContext;
    public BlogCategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; 
    }
   
    public async Task<IEnumerable<BlogCategory>> GetAllBlogCategoriesAsync(CancellationToken cancellationToken = default)
    {
        var temp = await _dbContext.BlogCategories.ToListAsync(cancellationToken);
        return await  _dbContext.BlogCategories
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<BlogCategory?> GetBlogCategoryByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.BlogCategories.Where(x => x.Id == id)
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task AddNewBlogCatgory(BlogCategory category, CancellationToken cancellationToken = default)
    {
        using(var trainsaction = await _dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                _dbContext.BlogCategories.Add(category);
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
