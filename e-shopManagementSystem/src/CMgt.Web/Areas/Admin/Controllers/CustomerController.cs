using Microsoft.AspNetCore.Mvc;

namespace CMgt.Web.Areas.Admin.Controllers;
public class CustomerController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
