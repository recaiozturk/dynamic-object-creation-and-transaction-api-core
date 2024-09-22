using MicromarinCase.Repositories.OrderDetails;

namespace MicromarinCase.Services.Products.Create
{
    public record CreateProductRequest(string Name, decimal Price, List<OrderDetail>? OrderDetails);
}
