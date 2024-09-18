

using MicromarinCase.Repositories.OrderDetails;

namespace MicromarinCase.Repositories.Products
{
    public class Product:BaseTable
    {
        public string ProductName { get; set; } = default!;
        public decimal Price { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = default!;
    }
}
