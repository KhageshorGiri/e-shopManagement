using CMgt.BLL.IServices;
using CMgt.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMgt.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _blogCategoryService;
    private readonly ISubCategoryService _blogSubCategoryService;
    public CategoryController(ICategoryService blogCategoryService, ISubCategoryService blogSubCategoryService)
    {
        _blogCategoryService = blogCategoryService;
        _blogSubCategoryService = blogSubCategoryService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.AllCategories = await _blogCategoryService.GetAllBlogCategoriesAsync();
        ViewBag.AllSubCategory = await _blogSubCategoryService.GetAllSubCategoriesAsync();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddBlogCategory([FromBody] Category blogCategory)
    {
        if (ModelState.IsValid)
        {
            await _blogCategoryService.AddBlogCategoryAsync(blogCategory);

            return Ok(new { success = true, message = "Blog category added successfully." });
        }

        return BadRequest(new { success = false, message = "Invalid data provided." });
    }


    [HttpPost]
    public async Task<IActionResult> AddBlogSubCategory([FromBody] SubCategory blogSubCategory)
    {
        if (ModelState.IsValid)
        {
            await _blogSubCategoryService.AddNewSubCategoryAsync(blogSubCategory);
            return Ok(new { success = true, message = "Blog sub category added successfully." });
        }

        return BadRequest(new { success = false, message = "Invalid data provided." });
    }
}
