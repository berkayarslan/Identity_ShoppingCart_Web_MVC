using ApplicationLayer.Models.DTOs.ShoppingCart;
using ApplicationLayer.Models.ViewModels.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.ShoppingCartServices
{
    public interface IShoppingCartService
    {
        Task AddProductToCartAsync(AddProductToCartDTO product);
        Task RemoveProductFromCartAsync(int id);
        Task<IEnumerable<ShoppingCartVM>> GetAllProductsFromCartAsync(int userID);
        Task DeleteCartForUser(int UserID);

    }
}
