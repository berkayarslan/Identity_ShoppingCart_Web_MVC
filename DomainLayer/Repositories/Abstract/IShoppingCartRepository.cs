using DomainLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Repositories.Abstract
{
    public interface IShoppingCartRepository : IBaseRepository<ShoppingCart>
    {
        Task AddToCartAsync(ShoppingCart cart);
        Task RemoveAllProductsForUserAsync(int userID);
    }
}
