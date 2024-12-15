using CMgt.BLL.IServices;
using CMgt.BLL.Services;
using CMgt.shared.ViewModels;
using CMgt.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace CMgt.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdcutService _productService;
        private readonly IOrderService _orderService;
        public HomeController(ILogger<HomeController> logger, IProdcutService prodcutService, IOrderService orderService)
        {
            _logger = logger;
            _productService = prodcutService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.allProducts = await _productService.GetAllProductsAsync();
            return View();
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> MyOrders()
        {
            var allOrders = await _orderService.GetAllOrdersByUserIdAsync(1);
            return View(allOrders);
        }

        //public IActionResult Cart()
        //{
        //    return View();
        //}
      
        public async Task<IActionResult> AllProducts()
        {
            ViewBag.allProducts = await _productService.GetAllProductsAsync();
            return View();
        }

        [Authorize(Roles = "User")]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var productDetails = await _productService.GetProductByIdAsync(id);
            return View(productDetails);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto newOrder)
        {
            await _orderService.AddNewOrderAsync(newOrder);
            return Json(new { success=true, messgae="Order Placed."});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
