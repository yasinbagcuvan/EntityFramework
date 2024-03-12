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
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //modelBuilder.Entity<Employee>().HasOne(e => e.EmployeeInfo)
            //                              .WithOne(ei => ei.Employee)
            //                              .HasForeignKey<EmployeeInfo>(ei => ei.Id);

            builder.HasOne(e => e.EmployeeInfo)
                                        .WithOne(ei => ei.Employee)
                                        .HasForeignKey<EmployeeInfo>(ei => ei.Id);

            builder.HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "Çalışan Adı 1",
                    Surname = "Çalışan Soyadı 1",
                    Title = "Reyon Çalışanı"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Çalışan Adı 2",
                    Surname = "Çalışan Soyadı 2",
                    Title = "Ürün Çalışanı"
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Çalışan Adı 3",
                    Surname = "Çalışan Soyadı 3",
                    Title = "Satış Çalışanı"
                });

           
        }
    }
}
