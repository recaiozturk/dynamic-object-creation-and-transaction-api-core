

using MicromarinCase.Repositories.OrderDetails;

namespace MicromarinCase.Services.Products
{
    public record ProductDto(int Id,string Name,decimal Price, List<OrderDetail>? OrderDetails);
}
