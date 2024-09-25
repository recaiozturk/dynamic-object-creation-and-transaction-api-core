
namespace MicromarinCase.Services.Orders
{
    public record OrderDto
    {
        public DateTime CreatedDate { get; set; }
        public int CustomerId { get; set; }
    }
}
