using ApplicationLayer.Models.DTOs.ShoppingCart;
using ApplicationLayer.Services.ShoppingCartServices;
using ApplicationLayer.Services.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Core_UI_Layer.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class PanelController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IUserService _userService;

        public PanelController(IShoppingCartService shoppingCartService, IUserService userService)
        {
            _shoppingCartService = shoppingCartService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            int userID = await _userService.GetUserIdAsync(User);
            var products = await _shoppingCartService.GetAllProductsFromCartAsync(userID);
            return View(products);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            //id=>productID
            AddProductToCartDTO product = new AddProductToCartDTO();
            product.AppUserID = await _userService.GetUserIdAsync(User);
            product.ProductID = id;
            product.Amount = 1;

            await _shoppingCartService.AddProductToCartAsync(product);
            return NoContent();
        }
    }
}
