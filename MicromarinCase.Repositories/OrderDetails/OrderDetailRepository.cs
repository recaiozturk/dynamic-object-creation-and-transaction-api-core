
namespace MicromarinCase.Repositories.OrderDetails
{
    public class OrderDetailRepository(AppDbContext context) : GenericRepository<OrderDetail>(context), IOrderDetailRepository
    {
    }
}
