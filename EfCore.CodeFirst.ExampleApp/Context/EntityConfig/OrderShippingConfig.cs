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
    public class OrderShippingConfig : IEntityTypeConfiguration<OrderShipping>
    {
         public void Configure(EntityTypeBuilder<OrderShipping> builder)
        {
            builder.HasKey(os => new { os.OrderId,os.ShippingId });
        }
        
    }
}
