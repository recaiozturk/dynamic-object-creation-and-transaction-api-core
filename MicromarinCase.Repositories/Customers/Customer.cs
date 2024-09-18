

using MicromarinCase.Repositories.Orders;

namespace MicromarinCase.Repositories.Customers
{
    public class Customer:BaseTable
    {
        public string Name { get; set; } = default!;
        public List<Order> Orders { get; set; } = default!;
    }
}
