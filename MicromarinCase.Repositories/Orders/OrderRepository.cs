
using Microsoft.EntityFrameworkCore;

namespace MicromarinCase.Repositories.Orders
{
    public class OrderRepository(AppDbContext context) : GenericRepository<Order>(context), IOrderRepository
    {
        public async Task<Order?> GetOrderWithOrderDetailsAsync(int id)
        {
            return await context.Orders.Include(c => c.OrderDetails).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
