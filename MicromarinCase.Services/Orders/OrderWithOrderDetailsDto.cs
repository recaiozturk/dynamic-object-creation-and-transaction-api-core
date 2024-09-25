using MicromarinCase.Services.OrderDetails;

namespace MicromarinCase.Services.Orders
{
    public class OrderWithOrderDetailsDto
    {
        public DateTime CratedDate { get; set; }
        public int CustomerId { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; } = default!;
    }
}
