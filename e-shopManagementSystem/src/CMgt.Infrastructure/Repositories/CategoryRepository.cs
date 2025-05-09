﻿using CMgt.Domain.Entities;
using CMgt.Domain.IRepositories;
using CMgt.Infrastrucutre.Data;
using Microsoft.EntityFrameworkCore;

namespace CMgt.Infrastrucutre.Repositories;

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

    public async Task DeleteCategory(Category category, CancellationToken cancellationToken = default)
    {
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync();
    }
}
