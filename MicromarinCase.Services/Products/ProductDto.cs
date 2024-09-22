

using MicromarinCase.Repositories.OrderDetails;
using MicromarinCase.Services.OrderDetails;

namespace MicromarinCase.Services.Products
{
    public record ProductDto(int Id,string Name,decimal Price, List<OrderDetailDto>? OrderDetails);
}
