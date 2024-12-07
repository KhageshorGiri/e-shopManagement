using CMgt.BLL.IServices;
using CMgt.BLL.Services;
using CMgt.shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMgt.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IProdcutService _prodcutService;
        public ProductController(ICategoryService categoryService, ISubCategoryService subCategoryService, IProdcutService prodcutService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _prodcutService = prodcutService;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _prodcutService.GetAllProductsAsync();
            return View(allProducts);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.AllCategoriesSelectList = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "CategoryName");
            ViewBag.AllSubCategoriesSelectList = new SelectList(await _subCategoryService.GetAllSubCategoriesAsync(), "Id", "SubCategoryName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductViewModel newProduct)
        {
            if (ModelState.IsValid)
            {
                await _prodcutService.AddProductAsync(newProduct);
                return Ok(new { success = true, message = "Product added successfully." });
            }

            return BadRequest(new { success = false, message = "Invalid data provided." });
        }
    }


}
