
using MicromarinCase.Services.Orders.Create;
using MicromarinCase.Services.Orders.Update;

namespace MicromarinCase.Services.Orders
{
    public interface IOrderService
    {
        Task<ServiceResult<OrderWithOrderDetailsDto>> GetOrderWithOrderDetailsAsync(int id);
        Task<ServiceResult<List<OrderDto>>> GetAllListAsync();
        Task<ServiceResult<OrderDto?>> GetByIdAsync(int id);
        Task<ServiceResult<CreateOrderResponse>> CreateAsync(CreateOrderRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateOrdertRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
