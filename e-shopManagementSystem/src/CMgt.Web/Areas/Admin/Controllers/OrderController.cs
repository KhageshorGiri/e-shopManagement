using CMgt.BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CMgt.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<IActionResult> Index()
    {
        var allOrders = await _orderService.GetAllOrdersAsync();
        return View(allOrders);
    }
}
