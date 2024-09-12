using DomainLayer.Entities.Abstract;
using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities.Concrete
{
    public class ShoppingCart : IEntity
    {
        public int ShoppingCartID { get; set; }
        public int AppUserID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }

        public AppUser? AppUser { get; set; }
        public Product? Product { get; set; }


        public DateTime AddedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
