using Microsoft.AspNetCore.Mvc;

namespace CMgt.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class HomeController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }
}
