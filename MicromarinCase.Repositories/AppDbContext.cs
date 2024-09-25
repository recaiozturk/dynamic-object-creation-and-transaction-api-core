
using MicromarinCase.Repositories.Customers;
using MicromarinCase.Repositories.OrderDetails;
using MicromarinCase.Repositories.Orders;
using MicromarinCase.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MicromarinCase.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<BaseTable> BaseTables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<BaseTable>().HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}
