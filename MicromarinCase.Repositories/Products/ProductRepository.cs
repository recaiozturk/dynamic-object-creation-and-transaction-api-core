
using MicromarinCase.Repositories.Orders;
using Microsoft.EntityFrameworkCore;

namespace MicromarinCase.Repositories.Products
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product>(context), IProductRepository
    {
        public async Task<Product?> GetProdcutWithOrderDetailsAsync(int id)
        {
            return await context.Products.Include(c => c.OrderDetails).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
