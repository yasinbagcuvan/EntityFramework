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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.Property(c => c.Name).HasColumnType("nvarchar(25)");

            builder.Property(c => c.Name).HasMaxLength(25).IsFixedLength(false).IsUnicode();
            builder.Property(c => c.Description).HasColumnType("ntext");

            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category);

            builder.HasData(new Category() { Id = 1, Name = "Category 1", Description = "Yok" });

        }
    }
}
