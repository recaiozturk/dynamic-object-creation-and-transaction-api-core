
using MicromarinCase.Repositories.OrderDetails;
using MicromarinCase.Services.OrderDetails;

namespace MicromarinCase.Services.Orders.Update
{
    public record UpdateOrdertRequest(int CustomerId, List<OrderDetailDto> OrderDetails=default!);

}
