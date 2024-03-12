using EfCore.CodeFirst.ExampleApp.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.ExampleApp.Context.EntityConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders);

            builder.HasOne(o => o.Employee)
                   .WithMany(c => c.Orders);


            builder.HasMany(o => o.OrderDetails)
                   .WithOne(c => c.Order);

            builder.HasOne(o => o.OrderShipping)
                   .WithOne(oc => oc.Order);

            builder.HasOne(o => o.OrderShipping)
                   .WithOne(oc => oc.Order)
                   .HasForeignKey<OrderShipping>(e => e.OrderId);
        }
    }
}
