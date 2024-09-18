

using MicromarinCase.Repositories.Orders;
using MicromarinCase.Repositories.Products;

namespace MicromarinCase.Repositories.OrderDetails
{
    public class OrderDetail:BaseTable
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = default!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
