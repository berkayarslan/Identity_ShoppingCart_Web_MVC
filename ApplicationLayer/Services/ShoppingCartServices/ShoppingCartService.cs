using ApplicationLayer.Models.DTOs.ShoppingCart;
using ApplicationLayer.Models.ViewModels.ShoppingCart;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.ShoppingCartServices
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task AddProductToCartAsync(AddProductToCartDTO product)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            _mapper.Map(product, shoppingCart);
            await _shoppingCartRepository.AddToCartAsync(shoppingCart);

        }

        public async Task DeleteCartForUser(int UserID)
        {
            await _shoppingCartRepository.RemoveAllProductsForUserAsync(UserID);
        }

        public async Task<IEnumerable<ShoppingCartVM>> GetAllProductsFromCartAsync(int userID)
        {
            List<ShoppingCartVM> newProducts = new List<ShoppingCartVM>();
            var products = _shoppingCartRepository.GetAllInclude().Include(x => x.Product).Where(x => x.AppUserID == userID).ToList();

            _mapper.Map(products, newProducts);

            return await Task.FromResult(newProducts);
        }

        public async Task RemoveProductFromCartAsync(int id)
        {
            await _shoppingCartRepository.DeleteAsync(id);
        }
    }
}
