using ApplicationLayer.Models.DTOs.Product;
using ApplicationLayer.Models.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services.ProductServices
{
    public interface IProductService
    {
        Task AddProductAsync(AddProductDTO product);
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDetailsVM> GetProductDetailsAsync(int productID);
        //Task DeleteProductAsync();
        //Task UpdateProductAsync();

    }
}
