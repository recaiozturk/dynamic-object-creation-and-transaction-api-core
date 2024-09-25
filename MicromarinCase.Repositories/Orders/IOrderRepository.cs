
namespace MicromarinCase.Repositories.Orders
{
    public interface IOrderRepository:IGenericRepository<Order>
    {
        Task<Order?> GetOrderWithOrderDetailsAsync(int id);
    }
}
