using CMgt.BLL.IServices;
using CMgt.BLL.Services;
using CMgt.shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMgt.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> AddProduct([FromForm] ProductViewModel newProduct)
        {
            if (ModelState.IsValid)
            {
                await _prodcutService.AddProductAsync(newProduct);
                return RedirectToAction("Index");
            }

            return BadRequest(new { success = false, message = "Invalid data provided." });
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct([FromForm] ProductViewModel newProduct)
        {
            await _prodcutService.UpdateProductAsync(newProduct);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            ViewBag.AllCategoriesSelectList = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "CategoryName");
            ViewBag.AllSubCategoriesSelectList = new SelectList(await _subCategoryService.GetAllSubCategoriesAsync(), "Id", "SubCategoryName");

            var product = await _prodcutService.GetProductByIdAsync(id);
            return View("_EditProductDetails", product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _prodcutService.DeleteProductAsync(id);
            return Ok(new { success = true, message = "Product deleted." });
        }
    }


}
