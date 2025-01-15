using CMgt.Domain.Entities;
using CMgt.shared.ViewModels;

namespace CMgt.Application.IServices;

public interface IOrderService
{
    Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync(CancellationToken cancellationToken = default);
    Task<Order> GetOrdersByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    Task AddNewOrderAsync(OrderDto newOrder, CancellationToken cancellationToken = default);
    Task UpdateOrderAsync(UpdateOrderDto updateOrder, CancellationToken cancellationToken = default);
}
