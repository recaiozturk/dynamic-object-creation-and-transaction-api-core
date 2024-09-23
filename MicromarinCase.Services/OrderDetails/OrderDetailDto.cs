


namespace MicromarinCase.Services.OrderDetails
{
    public record class OrderDetailDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
