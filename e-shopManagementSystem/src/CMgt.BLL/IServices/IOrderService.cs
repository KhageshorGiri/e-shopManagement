using CMgt.DAL.Entities;
using CMgt.shared.ViewModels;

namespace CMgt.BLL.IServices;

public interface IOrderService
{
    Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default);
    Task AddNewOrderAsync(OrderDto newOrder, CancellationToken cancellationToken = default);
}
