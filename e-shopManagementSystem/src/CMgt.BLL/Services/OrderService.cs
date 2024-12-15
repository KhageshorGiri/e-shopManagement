using CMgt.BLL.IServices;
using CMgt.DAL.Entities;
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
            UserId = 1,
            Quantity = newOrder.Quantity,
            ProductId = newOrder.ProductId
        };

        await _orderRepository.AddNewOrderAsync(order, cancellationToken);
    }

    public async Task<IEnumerable<OrderViewModel>> GetAllOrdersAsync(CancellationToken cancellationToken = default)
    {
        return await _orderRepository.GetAllOrdersAsync(cancellationToken);
    }

    public async Task<IEnumerable<OrderViewModel>> GetAllOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _orderRepository.GetAllOrdersByUserIdAsync(userId, cancellationToken);
    }
}
