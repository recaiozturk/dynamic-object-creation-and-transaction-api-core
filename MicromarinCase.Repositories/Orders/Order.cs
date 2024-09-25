
using MicromarinCase.Repositories.Customers;
using MicromarinCase.Repositories.OrderDetails;

namespace MicromarinCase.Repositories.Orders
{
    public class Order:BaseTable
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public List<OrderDetail> OrderDetails { get; set; } = default!;
    }
}
