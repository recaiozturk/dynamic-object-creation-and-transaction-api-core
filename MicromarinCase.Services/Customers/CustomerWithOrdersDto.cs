using MicromarinCase.Services.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicromarinCase.Services.Customers
{
    public class CustomerWithOrdersDto
    {
        public string Name { get; set; } = default!;
        public List<OrderDto>? Orders { get; set; }
    }
}
