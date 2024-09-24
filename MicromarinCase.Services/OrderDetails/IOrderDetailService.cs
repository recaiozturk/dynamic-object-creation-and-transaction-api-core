
using MicromarinCase.Services.OrderDetails.Create;
using MicromarinCase.Services.OrderDetails.Update;

namespace MicromarinCase.Services.OrderDetails
{
    public interface IOrderDetailService
    {
        Task<ServiceResult<List<OrderDetailDto>>> GetAllListAsync();
        Task<ServiceResult<OrderDetailDto?>> GetByIdAsync(int id);
        Task<ServiceResult<CreateOrderDetailResponse>> CreateAsync(CreateOrderDetailRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateOrderDetailRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
