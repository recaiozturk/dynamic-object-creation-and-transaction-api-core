using MicromarinCase.Services.Customers;
using Microsoft.AspNetCore.Mvc;
using MicromarinCase.Services.Customers.Create;
using MicromarinCase.Services.Customers.Update;

namespace MicromarinCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController(ICustomerService customerService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await customerService.GetAllListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await customerService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerRequest request)
        {

            return CreateActionResult(await customerService.CreateAsync(request));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerRequest request)
        {
            return CreateActionResult(await customerService.UpdateAsync(id, request));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await customerService.DeleteAsync(id));
        }
    }
}
