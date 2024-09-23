using MicromarinCase.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MicromarinCase.Repositories.Orders;
using MicromarinCase.Services.Orders.Create;
using MicromarinCase.Services.Orders.Update;


namespace MicromarinCase.Services.Orders
{
    public class OrderService(IOrderRepository orderRepository,IUnitOfWork unitOfWork,IMapper mapper):IOrderService
    {
        public async Task<ServiceResult<List<OrderDto>>> GetAllListAsync()
        {
            var orders = await orderRepository.GetAll().ToListAsync();

            var ordersAsDto = mapper.Map<List<OrderDto>>(orders);

            return ServiceResult<List<OrderDto>>.Success(ordersAsDto);
        } 
  
        public async Task<ServiceResult<OrderDto?>> GetByIdAsync(int id)
        {
            var order =await orderRepository.GetByIdAsync(id);

            if (order is null)
                return ServiceResult<OrderDto?>.Fail("Sipariş bulunamadi", HttpStatusCode.NotFound);

            var orderAsDto = mapper.Map<OrderDto>(order);


            return ServiceResult<OrderDto>.Success(orderAsDto)!;
        }

        public async Task<ServiceResult<CreateOrderResponse>> CreateAsync(CreateOrderRequest request)
        {


            var order =mapper.Map<Order>(request);

            await orderRepository.AddAsync(order);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateOrderResponse>.SuccessAsCreated(new CreateOrderResponse(order.Id),$"api/orders/{order.Id}");
        }

        public async Task<ServiceResult> UpdateAsync(int id,UpdateOrdertRequest request)
        {
            var order=await orderRepository.GetByIdAsync(id);

            if (order is null)
                return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);

            order = mapper.Map(request, order);

            orderRepository.Update(order);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var order = await orderRepository.GetByIdAsync(id);

            if (order is null)
                return ServiceResult.Fail("Sipariş buluınamadı", HttpStatusCode.NotFound);

            order.IsDeleted=true;
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

    }
}
