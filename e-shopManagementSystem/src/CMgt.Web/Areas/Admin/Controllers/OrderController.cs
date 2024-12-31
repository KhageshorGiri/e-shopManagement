using CMgt.BLL.IServices;
using CMgt.BLL.Services;
using CMgt.shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMgt.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
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

    [HttpPost] 
    public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto order)
    {
        if (ModelState.IsValid)
        {
            await _orderService.UpdateOrderAsync(order);
            return Ok(new { success = true, message = "Order status updated successfully." });
        }

        return BadRequest(new { success = false, message = "Invalid data provided." });
    }
}
