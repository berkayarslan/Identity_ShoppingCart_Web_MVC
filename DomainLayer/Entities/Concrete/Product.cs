using DomainLayer.Entities.Abstract;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Concrete
{
    public class Product : IEntity
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public int CounterForCart { get; set; } = 0;


        public DateTime AddedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public RecordStatus RecordStatus { get; set; }


        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        public ICollection<ShoppingCart>? ShoppingCarts { get; set; }
    }
}
