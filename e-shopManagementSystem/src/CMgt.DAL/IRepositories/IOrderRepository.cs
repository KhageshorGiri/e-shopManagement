using CMgt.Domain.Entities;
using CMgt.shared.ViewModels;

namespace CMgt.Domain.IRepositories;

public interface IOrderRepository
{
    Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    Task<Order> GetOrdersByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddNewOrderAsync(Order newOrder, CancellationToken cancellationToken = default);
    Task UpdateOrderAsync(Order updateOrder, CancellationToken cancellationToken = default);
}
