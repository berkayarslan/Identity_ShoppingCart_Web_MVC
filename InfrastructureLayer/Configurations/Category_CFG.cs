using DomainLayer.Entities.Concrete;
using DomainLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Configurations
{
    public class Category_CFG : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new Category { CategoryID=1, CategoryName="Elektronik", AddedDate=DateTime.Now, RecordStatus = RecordStatus.Added },
                new Category { CategoryID=2, CategoryName="Cep Telefonu", AddedDate=DateTime.Now, RecordStatus = RecordStatus.Added },
                new Category { CategoryID=3, CategoryName="Kırtasiye", AddedDate=DateTime.Now, RecordStatus = RecordStatus.Added },
                new Category { CategoryID=4, CategoryName="Hobi", AddedDate=DateTime.Now, RecordStatus = RecordStatus.Added }
                );
        }
    }
}
