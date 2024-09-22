using MicromarinCase.Repositories.OrderDetails;
using MicromarinCase.Services.OrderDetails;

namespace MicromarinCase.Services.Products.Create
{
    public record CreateProductRequest(string Name, decimal Price, List<OrderDetailDto>? OrderDetails);
}
