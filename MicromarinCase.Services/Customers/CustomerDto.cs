
using MicromarinCase.Services.Orders;

namespace MicromarinCase.Services.Customers
{
    public record CustomerDto
    {
        public string Name { get; set; } = default!;
        public List<OrderDto> Orders { get; set; } = default!;
    }
}
