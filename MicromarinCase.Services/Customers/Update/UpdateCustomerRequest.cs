
using MicromarinCase.Services.Orders;

namespace MicromarinCase.Services.Customers.Update
{
    public record UpdateCustomerRequest(string Name, List<OrderDto>? Orders);

}
