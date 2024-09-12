using DomainLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models.DTOs
{
    public class LoginResultDTO
    {
        public bool IsRegisteredUser { get; set; }
        public bool IsAdmin { get; set; } = false;
        public AppUser AppUser { get; set; }
    }
}
