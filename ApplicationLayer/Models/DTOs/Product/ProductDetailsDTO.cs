using DomainLayer.Entities.Concrete;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.DTOs.Product
{
    public class ProductDetailsDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }

        //public int CategoryID { get; set; } //!!!
    }
}
