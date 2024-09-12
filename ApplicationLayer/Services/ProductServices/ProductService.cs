using ApplicationLayer.Models.DTOs.Product;
using ApplicationLayer.Models.ViewModels.Product;
using AutoMapper;
using DomainLayer.Entities.Concrete;
using DomainLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddProductAsync(AddProductDTO product)
        {
            Product newProduct = new Product();
            _mapper.Map(product, newProduct);
            await _repository.AddAsync(newProduct);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var result = await _repository.GetAllAsync();
            List<ProductDTO> products = new List<ProductDTO>();
            _mapper.Map(result, products);
            return products;
        }

        public async Task<ProductDetailsVM> GetProductDetailsAsync(int productID)
        {
            var product = await _repository.GetAllInclude().Include(x => x.Category).Where(x => x.ProductID == productID).SingleOrDefaultAsync();

            ProductDetailsVM productVM = new ProductDetailsVM();

            _mapper.Map(product, productVM);

            return productVM;
        }
    }
}
