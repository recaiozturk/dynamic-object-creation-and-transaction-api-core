
namespace MicromarinCase.Repositories.Orders
{
    public class OrderRepository(AppDbContext context) : GenericRepository<Order>(context), IOrderRepository
    {
    }
}
