using MicromarinCase.Services.OrderDetails;

namespace MicromarinCase.Services.Products
{
    public record ProductWithOrderDetailDto(int Id, string Name, decimal Price, List<OrderDetailDto>? OrderDetails);

}
