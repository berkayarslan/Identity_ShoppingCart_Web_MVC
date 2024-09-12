using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories.Concrete
{
    public class ShoppingCartRepository : BaseRepository<ShoppingCart>, IShoppingCartRepository
    {
        public async Task AddToCartAsync(ShoppingCart cart)
        {
            // cart içinde gelen product ve user önceden eklenmişmi?
            //evetse update
            //değilse insert

            var result = _context.ShoppingCarts.Where(x => x.AppUserID == cart.AppUserID && x.ProductID == cart.ProductID).SingleOrDefault();

            if (result == null)
                _context.ShoppingCarts.Add(cart);
            else
            {
                result.Amount += 1;
                _context.ShoppingCarts.Update(result);
            }
            //sepete eklenince sayacı arttır...

            var product = _context.Products.Find(cart.ProductID);
            product.CounterForCart += 1;
            _context.Products.Update(product);

            await _context.SaveChangesAsync();

        }

        public Task RemoveAllProductsForUserAsync(int userID)
        {
            var results = _context.ShoppingCarts.Where(x => x.AppUserID == userID);
            _context.RemoveRange(results);

            return Task.CompletedTask;
        }
    }
}
