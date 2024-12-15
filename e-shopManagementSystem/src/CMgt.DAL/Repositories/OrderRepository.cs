using CMgt.DAL.Data;
using CMgt.DAL.Entities;
using CMgt.DAL.IRepositories;
using CMgt.shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CMgt.DAL.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;
    public OrderRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddNewOrderAsync(Order newOrder, CancellationToken cancellationToken = default)
    {
        using(var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                _dbContext.Orders.Add(newOrder);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public async Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync(CancellationToken cancellationToken = default)
    {
        var allIOrders = await _dbContext.Orders
           .Include(o => o.Product)
           .Include(o=>o.User)
           .Select(o => new OrderViewModel
           {
               OrderDate = o.OrderDate,
               ProductName = o.Product.ProductName,
               Quantity = o.Quantity,
               Price = o.Product.Price,
               Size = o.Product.Size.ToString(),
               Brand = o.Product.Brand,
               UserName = o.User.UserName
           })
           .AsNoTracking()
           .ToListAsync(cancellationToken);

        return allIOrders;
    }

    public async Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        var allIOrders = await _dbContext.Orders
            .Where(x=>x.UserId == userId)
            .Include(o => o.Product)
            .Select(o => new OrderViewModel
            {
                OrderDate = o.OrderDate,
                ProductName = o.Product.ProductName,
                Quantity = o.Quantity,
                Price = o.Product.Price,
                Size = o.Product.Size.ToString(),
                Brand = o.Product.Brand,
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return allIOrders;
    }
}
