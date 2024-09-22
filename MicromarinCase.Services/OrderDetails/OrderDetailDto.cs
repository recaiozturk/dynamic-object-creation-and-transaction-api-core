
using MicromarinCase.Services.Orders;
using MicromarinCase.Services.Products;

namespace MicromarinCase.Services.OrderDetails
{
    public record class OrderDetailDto
    {
        public int OrderId { get; set; }
        public OrderDto Order { get; set; } = default!;
        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
