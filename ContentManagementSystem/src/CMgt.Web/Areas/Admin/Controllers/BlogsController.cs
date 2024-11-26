using CMgt.BLL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CMgt.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class BlogsController : Controller
{
    private readonly IBlogCategoryService _blogCategoryService;
    private readonly IBlogSubCategoryService _blogSubCategoryService;
    public BlogsController(IBlogCategoryService blogCategoryService, IBlogSubCategoryService blogSubCategoryService)
    {
        _blogCategoryService = blogCategoryService;
        _blogSubCategoryService = blogSubCategoryService;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.AllCategories = await _blogCategoryService.GetAllBlogCategoriesAsync();
        ViewBag.AllSubCategory = await _blogSubCategoryService.GetAllSubCategoriesAsync();
        return View();
    }
}
