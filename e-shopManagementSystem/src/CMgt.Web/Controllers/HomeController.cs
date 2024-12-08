using CMgt.BLL.IServices;
using CMgt.BLL.Services;
using CMgt.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CMgt.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProdcutService _productService;
        public HomeController(ILogger<HomeController> logger, IProdcutService prodcutService)
        {
            _logger = logger;
            _productService = prodcutService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.allProducts = await _productService.GetAllProductsAsync();
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
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
