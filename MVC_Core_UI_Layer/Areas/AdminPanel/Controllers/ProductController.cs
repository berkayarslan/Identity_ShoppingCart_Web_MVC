using ApplicationLayer.Models.DTOs.Product;
using ApplicationLayer.Services.CategoryServices;
using ApplicationLayer.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Core_UI_Layer.Areas.AdminPanel.Models;

namespace MVC_Core_UI_Layer.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetAllCategoriesAsync(), "CategoryID", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductVM product)
        {
            //resim ilgili klasöre yüklenmeli...
            string strPath = "wwwroot/ProductPictures/" + product.PictureFile.FileName;
            FileStream fs = new FileStream(strPath, FileMode.Create);
            await product.PictureFile.CopyToAsync(fs);
            fs.Close();

            AddProductDTO newProduct = new AddProductDTO();
            newProduct.ProductName = product.ProductName;
            newProduct.Picture = product.PictureFile.FileName;
            newProduct.Price = product.Price;
            newProduct.Description = product.Description;
            newProduct.CategoryID = product.CategoryID;
            newProduct.Stock = product.Stock;

            await _productService.AddProductAsync(newProduct);

            return RedirectToAction("Index");
        }
    }
}
