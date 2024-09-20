
using MicromarinCase.Repositories.Customers;
using MicromarinCase.Repositories.OrderDetails;
using MicromarinCase.Repositories.Orders;
using MicromarinCase.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace MicromarinCase.Repositories
{
    public class AppDbContex(DbContextOptions<AppDbContex> options) : DbContext(options)
    {
        public DbSet<BaseTable> BaseTables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            // Customer ve Order arasındaki ilişki (One to Many)
            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .HasForeignKey(o => o.CustomerId).OnDelete(DeleteBehavior.Restrict);

            // Order ve OrderDetail arasındaki ilişki (One to Many)
            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne(od => od.Order)
            //    .WithMany(o => o.OrderDetails)
            //    .HasForeignKey(od => od.OrderId).OnDelete(DeleteBehavior.Restrict);

            // Product ve OrderDetail arasındaki ilişki (One to Many)
            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne(od => od.Product)
            //    .WithMany(p => p.OrderDetails)
            //    .HasForeignKey(od => od.ProductId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<BaseTable>().HasQueryFilter(p => !p.IsDeleted);

        }
    }
}
