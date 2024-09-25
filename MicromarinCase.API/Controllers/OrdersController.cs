
using Microsoft.AspNetCore.Mvc;
using MicromarinCase.Services.Orders;
using MicromarinCase.Services.Orders.Create;
using MicromarinCase.Services.Orders.Update;

namespace MicromarinCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await orderService.GetAllListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await orderService.GetByIdAsync(id));
        }

        [HttpGet("{id}/order-details")]
        public async Task<IActionResult> GetOrderWithOrderDetails(int id)
        {
            return CreateActionResult(await orderService.GetOrderWithOrderDetailsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {

            return CreateActionResult(await orderService.CreateAsync(request));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateOrdertRequest request)
        {
            return CreateActionResult(await orderService.UpdateAsync(id, request));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await orderService.DeleteAsync(id));
        }
    }
}
