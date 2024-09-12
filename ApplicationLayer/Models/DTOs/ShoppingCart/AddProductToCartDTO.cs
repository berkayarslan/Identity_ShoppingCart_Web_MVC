using DomainLayer.Entities.Concrete;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.DTOs.ShoppingCart
{
    public class AddProductToCartDTO
    {
        public int AppUserID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }

    }
}
