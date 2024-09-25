
using MicromarinCase.Services.Products.Create;
using MicromarinCase.Services.Products.Update;

namespace MicromarinCase.Services.Products
{
    public interface IProductService
    {
        Task<ServiceResult<ProductWithOrderDetailDto>> GetProductWithOrderDetailsAsync(int id);
        Task<ServiceResult<List<ProductDto>>> GetAllListAsync();
        Task<ServiceResult<ProductDto?>> GetByIdAsync(int id);
        Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
