using CMgt.BLL.IServices;
using CMgt.DAL.Entities;
using CMgt.DAL.Entities.Enums;
using CMgt.DAL.IRepositories;
using CMgt.shared.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CMgt.BLL.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrderService(IOrderRepository orderRepository,  IHttpContextAccessor httpContextAccessor)
    {
        _orderRepository = orderRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task AddNewOrderAsync(OrderDto newOrder, CancellationToken cancellationToken = default)
    {
        var user = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (user is null)
            throw new ArgumentNullException("User not found");

        Order order = new()
        {
            OrderDate = DateTime.Now,
            UserId = Convert.ToInt32(user),
            Quantity = newOrder.Quantity,
            ProductId = newOrder.ProductId,
            Status = OrderStatus.Pending,
        };

        await _orderRepository.AddNewOrderAsync(order, cancellationToken);
    }

    public async Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync(CancellationToken cancellationToken = default)
    {
        return await _orderRepository.GetAllOrdersAsync(cancellationToken);
    }

    public async Task<Order> GetOrdersByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _orderRepository.GetOrdersByIdAsync(id);
    }

    public async Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _orderRepository.GetAllOrdersByUserIdAsync(userId, cancellationToken);
    }


    public async Task UpdateOrderAsync(UpdateOrderDto updateOrder, CancellationToken cancellationToken = default)
    {
        var existingOrder = await _orderRepository.GetOrdersByIdAsync(updateOrder.OrderId);
        if (existingOrder != null)
        {
            existingOrder.Status = (OrderStatus)updateOrder.Status;
            await _orderRepository.UpdateOrderAsync(existingOrder);
        }
    }
}
