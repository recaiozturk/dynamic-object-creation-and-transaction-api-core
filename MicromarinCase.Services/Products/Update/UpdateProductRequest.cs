using MicromarinCase.Repositories.OrderDetails;

namespace MicromarinCase.Services.Products.Update
{
    public record UpdateProductRequest(string Name, decimal Price, List<OrderDetail>? OrderDetails);

}
