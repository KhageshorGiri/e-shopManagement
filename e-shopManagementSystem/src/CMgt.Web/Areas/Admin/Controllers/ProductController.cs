using CMgt.BLL.IServices;
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
        public ProductController(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.AllCategoriesSelectList = new SelectList(await _categoryService.GetAllCategoriesAsync(), "Id", "CategoryName");
            ViewBag.AllSubCategoriesSelectList = new SelectList(await _subCategoryService.GetAllSubCategoriesAsync(), "Id", "SubCategoryName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }
    }


}
