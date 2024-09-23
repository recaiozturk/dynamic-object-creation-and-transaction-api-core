using MicromarinCase.Repositories.OrderDetails;
using MicromarinCase.Services.OrderDetails;

namespace MicromarinCase.Services.Orders.Create
{
    public record CreateOrderRequest(int CustomerId, List<OrderDetailDto> OrderDetails =default!);
}
