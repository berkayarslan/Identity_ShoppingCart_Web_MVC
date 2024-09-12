using ApplicationLayer.Models.DTOs.Category;
using ApplicationLayer.Models.DTOs.Product;
using ApplicationLayer.Models.DTOs.ShoppingCart;
using ApplicationLayer.Models.ViewModels.Product;
using ApplicationLayer.Models.ViewModels.ShoppingCart;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Mapper
{
    public class ProductProjectMapper : Profile
    {
        public ProductProjectMapper()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, AddProductDTO>().ReverseMap();


            CreateMap<Product, ProductDetailsVM>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(y => y.Category.CategoryName))
                .ReverseMap();


            CreateMap<ShoppingCart, AddProductToCartDTO>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartVM>()
                .ForMember(x => x.ProductName, y => y.MapFrom(y => y.Product.ProductName))
                .ForMember(x => x.Price, y => y.MapFrom(y => y.Product.Price))
                .ReverseMap();
        }
    }
}
