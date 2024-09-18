
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
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //projedeki tüm Configurationları uygula
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
