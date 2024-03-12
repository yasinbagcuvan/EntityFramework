using EfCore.CodeFirst.ExampleApp.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.ExampleApp.Context.EntityConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                    new Product() { Id = 1, Name = "Product 1 ", Description = "Yok", Price = 12.00m, Stock = 20, IsActive = true, CategoryId =1 },
                    new Product() { Id = 2, Name = "Product 2 ", Description = "Yok", Price = 17.00m, Stock = 10, IsActive = true, CategoryId = 1},
                    new Product() { Id = 3, Name = "Product 3 ", Description = "Yok", Price = 9.00m, Stock = 42, IsActive = true, CategoryId = 1 }
                           );
        }
    }
}
