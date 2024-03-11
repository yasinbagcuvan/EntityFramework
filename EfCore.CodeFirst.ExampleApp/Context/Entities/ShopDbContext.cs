using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //modelBuilder.Entity<Customer>().HasKey(c => c.CustomerNumber);
            //modelBuilder.Entity<Customer>().Property(c => c.CustomerNumber).UseIdentityColumn(1, 1);
            //modelBuilder.Entity<Customer>().Property(c => c.Surname).HasMaxLength(15).IsUnicode(false);
            //modelBuilder.Entity<Customer>().Property(c => c.Address).HasMaxLength(50).IsFixedLength(true);
            //modelBuilder.Entity<Customer>().Property(c => c.Address).IsRequired(false);
            //modelBuilder.Entity<Customer>().Property(c => c.Email).IsRequired();
            //modelBuilder.Entity<Customer>().ToTable("Musteriler");

            modelBuilder.Entity<Employee>().HasOne(e => e.EmployeeInfo)
                                           .WithOne(ei => ei.Employee)
                                           .HasForeignKey<EmployeeInfo>(ei => ei.Id);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees {  get; set; }
        public DbSet<EmployeeInfo> EmployeesInfo { get; set; }
    }
}
