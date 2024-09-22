

using MicromarinCase.Repositories.Customers;
using MicromarinCase.Repositories.OrderDetails;
using MicromarinCase.Services.Customers;
using MicromarinCase.Services.OrderDetails;

namespace MicromarinCase.Services.Orders
{
    public record OrderDto
    {
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; } = default!;
        public List<OrderDetailDto> OrderDetails { get; set; } = default!;
    }
}
