using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.ViewModels.ShoppingCart
{
    public class ShoppingCartVM
    {
        public int ShoppingCartID { get; set; }
        public int AppUserID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }

        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
