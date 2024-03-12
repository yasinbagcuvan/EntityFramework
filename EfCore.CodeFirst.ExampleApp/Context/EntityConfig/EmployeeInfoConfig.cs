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
    public class EmployeeInfoConfig : IEntityTypeConfiguration<EmployeeInfo>
    {
        public void Configure(EntityTypeBuilder<EmployeeInfo> builder)
        {
            builder.HasData(
               new EmployeeInfo()
               {
                   Id = 2,
                   Phone = "0123456789",
                   Email = "mail@mail.com",
                   Birthdate = new DateOnly(1990, 1, 2)
               },
               new EmployeeInfo()
               {
                   Id = 3,
                   Phone = "987654321",
                   Email = "info@mail.com",
                   Birthdate = new DateOnly(1995, 5, 6)
               }
               );
        }
    }
}
