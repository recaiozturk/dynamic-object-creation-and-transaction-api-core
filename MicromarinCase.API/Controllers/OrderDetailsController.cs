using MicromarinCase.Services.OrderDetails;
using MicromarinCase.Services.OrderDetails.Create;
using MicromarinCase.Services.OrderDetails.Update;
using Microsoft.AspNetCore.Mvc;

namespace MicromarinCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController(IOrderDetailService orderDetailService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await orderDetailService.GetAllListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await orderDetailService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDetailRequest request)
        {

            return CreateActionResult(await orderDetailService.CreateAsync(request));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateOrderDetailRequest request)
        {
            return CreateActionResult(await orderDetailService.UpdateAsync(id, request));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await orderDetailService.DeleteAsync(id));
        }
    }
}
