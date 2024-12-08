using Microsoft.AspNetCore.Mvc;

namespace CMgt.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class OrderController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
