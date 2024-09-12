using DomainLayer.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Configurations
{
    public class AppUser_CFG : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            AppUser user = new AppUser
            {
                Id = 1,
                Name = "Super",
                Surname = "Admin",
                Address = "",
                Email = "super@admin.com",
                NormalizedEmail = "SUPER@ADMIN.COM",
                EmailConfirmed = false,
                UserName = "spRadmN",
                NormalizedUserName = "SPRADMN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "spr_123_Admn");

            builder.HasData(user);
        }
    }
}
