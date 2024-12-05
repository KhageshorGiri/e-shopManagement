using CMgt.BLL.IServices;
using CMgt.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMgt.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly ISubCategoryService _subCategoryService;
    public CategoryController(ICategoryService categoryService, ISubCategoryService subCategoryService)
    {
        _categoryService = categoryService;
        _subCategoryService = subCategoryService;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["CategoryForm"] = new Category() { CategoryName = string.Empty, Description = string.Empty };
        ViewData["SubCategoryForm"] = new SubCategory() { SubCategoryName = string.Empty, Description = string.Empty };

        var allCategories = await _categoryService.GetAllCategoriesAsync();

        ViewBag.AllCategories = allCategories;
        ViewBag.AllCategoriesSelectList = new SelectList(allCategories, "Id", "CategoryName");
        ViewBag.AllSubCategories = await _subCategoryService.GetAllSubCategoriesAsync();
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] Category blogCategory)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.AddCategoryAsync(blogCategory);

            return Ok(new { success = true, message = "Category added successfully." });
        }

        return BadRequest(new { success = false, message = "Invalid data provided." });
    }


    [HttpPost]
    public async Task<IActionResult> AddSubCategory([FromBody] SubCategory blogSubCategory)
    {
        if (ModelState.IsValid)
        {
            await _subCategoryService.AddNewSubCategoryAsync(blogSubCategory);
            return Ok(new { success = true, message = "Sub category added successfully." });
        }

        return BadRequest(new { success = false, message = "Invalid data provided." });
    }
}
