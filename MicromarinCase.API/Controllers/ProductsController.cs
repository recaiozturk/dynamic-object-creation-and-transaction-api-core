using MicromarinCase.Services.Products.Create;
using MicromarinCase.Services.Products.Update;
using MicromarinCase.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace MicromarinCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await productService.GetAllListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await productService.GetByIdAsync(id));
        }

        [HttpGet("{id}/order-details")]
        public async Task<IActionResult> GetproductWithOrderDetails(int id)
        {
            return CreateActionResult(await productService.GetProductWithOrderDetailsAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {

            return CreateActionResult(await productService.CreateAsync(request));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateProductRequest request)
        {
            return CreateActionResult(await productService.UpdateAsync(id, request));
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await productService.DeleteAsync(id));
        }

    }
}
