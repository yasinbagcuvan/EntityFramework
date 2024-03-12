using EfCore.CodeFirst.ExampleApp.Context.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EfCore.CodeFirst.ExampleApp.Context.Entities
{
    public class ShopDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=ANK3-YZLMORT-15\\MSSQLSERVERANK16;Initial Catalog=ShopDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new EmployeeConfig());
            //modelBuilder.ApplyConfiguration(new OrderShippingConfig());
            //modelBuilder.ApplyConfiguration(new ShippingConfig());
            //modelBuilder.ApplyConfiguration(new OrderDetailConfig());
            //modelBuilder.ApplyConfiguration(new OrderConfig());
            //modelBuilder.ApplyConfiguration(new CategoryConfig());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            #region MyRegion
            //modelbuilder.entity<customer>().haskey(c => c.customernumber);
            //modelbuilder.entity<customer>().property(c => c.customernumber).useıdentitycolumn(1, 1);
            //modelbuilder.entity<customer>().property(c => c.surname).hasmaxlength(15).ısunicode(false);
            //modelbuilder.entity<customer>().property(c => c.address).hasmaxlength(50).ısfixedlength(true);
            //modelbuilder.entity<customer>().property(c => c.address).ısrequired(false);
            //modelbuilder.entity<customer>().property(c => c.email).ısrequired();
            //modelbuilder.entity<customer>().totable("musteriler");

            //modelbuilder.entity<employee>().hasone(e => e.employeeınfo)
            //                               .withone(ei => ei.employee)
            //                               .hasforeignkey<employeeınfo>(ei => ei.ıd);

            //modelbuilder.entity<order>().hasone(o => o.customer)
            //                            .withmany(c => c.orders);

            //modelbuilder.entity<order>().hasone(o => o.employee)
            //                            .withmany(c => c.orders);


            //modelbuilder.entity<order>().hasmany(o => o.orderdetails)
            //                            .withone(c => c.order);

            //modelbuilder.entity<orderdetail>().hasone(o => o.product)
            //                                  .withmany(c => c.orderdetails);

            //modelbuilder.entity<order>().hasone(o => o.ordershipping)
            //                            .withone(oc => oc.order);

            //modelbuilder.entity<order>().hasone(o => o.ordershipping)
            //                            .withone(oc => oc.order)
            //                            .hasforeignkey<ordershipping>(e => e.orderıd);

            //modelbuilder.entity<ordershipping>()
            //            .haskey(os => new { os.orderıd, os.shippingıd });

            //modelbuilder.entity<shipping>().hasmany(o => o.ordershippings)
            //                               .withone(oc => oc.shipping);

            //modelbuilder.entity<employee>().hasdata(
            //    new employee()
            //    {
            //        ıd = 1,
            //        name = "çalışan adı 1",
            //        surname = "çalışan soyadı 1",
            //        title = "reyon çalışanı"
            //    },
            //    new employee()
            //    {
            //        ıd = 2,
            //        name = "çalışan adı 2",
            //        surname = "çalışan soyadı 2",
            //        title = "ürün çalışanı"
            //    },
            //    new employee()
            //    {
            //        ıd = 3,
            //        name = "çalışan adı 3",
            //        surname = "çalışan soyadı 3",
            //        title = "satış çalışanı"
            //    });

            //modelbuilder.entity<employeeınfo>().hasdata(
            //   new employeeınfo()
            //   {
            //       ıd = 2,
            //       phone = "0123456789",
            //       email = "mail@mail.com",
            //       birthdate = new dateonly(1990, 1, 2)
            //   },
            //   new employeeınfo()
            //   {
            //       ıd = 3,
            //       phone = "987654321",
            //       email = "info@mail.com",
            //       birthdate = new dateonly(1995, 5, 6)
            //   }
            //   );


            //modelbuilder.entity<product>().hasdata(
            //new product() { ıd = 1, name = "product 1 ", description = "yok", price = 12.00m, stock = 20, ısactive = true },
            //new product() { ıd = 2, name = "product 2 ", description = "yok", price = 17.00m, stock = 10, ısactive = true },
            //new product() { ıd = 3, name = "product 3 ", description = "yok", price = 9.00m, stock = 42, ısactive = true }
            //); 
            #endregion

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees {  get; set; }
        public DbSet<EmployeeInfo> EmployeesInfo { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderShipping> ShippingDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
