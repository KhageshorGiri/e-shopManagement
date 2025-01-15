using CMgt.Domain.Entities;
using CMgt.Domain.IRepositories;
using CMgt.Infrastrucutre.Data;
using CMgt.shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CMgt.Infrastrucutre.Repositories;

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
               Id = o.Id,
               OrderDate = o.OrderDate,
               ProductName = o.Product.ProductName,
               Quantity = o.Quantity,
               Price = o.Product.Price,
               Size = o.Product.Size.ToString(),
               Brand = o.Product.Brand,
               UserName = o.User.UserName,
               Status = Convert.ToInt32(o.Status)
           })
           .AsNoTracking()
           .ToListAsync(cancellationToken);

        return allIOrders;
    }

    public async Task<Order> GetOrdersByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var order = await _dbContext.Orders
            .Where(o=>o.Id == id)
           .AsNoTracking()
           .FirstOrDefaultAsync(cancellationToken);

        return order;
    }

    public async Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        var allIOrders = await _dbContext.Orders
            .Where(x=>x.UserId == userId)
            .Include(o => o.Product)
            .Select(o => new OrderViewModel
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                ProductName = o.Product.ProductName,
                Quantity = o.Quantity,
                Price = o.Product.Price,
                Size = o.Product.Size.ToString(),
                Brand = o.Product.Brand,
                Status = Convert.ToInt32(o.Status)
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return allIOrders;
    }

    public async Task UpdateOrderAsync(Order updateOrder, CancellationToken cancellationToken = default)
    {
        using (var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken))
        {
            try
            {
                _dbContext.Orders.Update(updateOrder);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
