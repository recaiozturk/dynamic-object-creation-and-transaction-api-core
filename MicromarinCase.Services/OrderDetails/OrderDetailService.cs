using MicromarinCase.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MicromarinCase.Repositories.OrderDetails;
using MicromarinCase.Services.OrderDetails;
using MicromarinCase.Services.OrderDetails.Create;
using MicromarinCase.Services.OrderDetails.Update;


namespace MicromarinCase.Services.Orders
{
    public class OrderDetailService(IOrderDetailRepository orderDetailRepository,IUnitOfWork unitOfWork,IMapper mapper):IOrderDetailService
    {
        public async Task<ServiceResult<List<OrderDetailDto>>> GetAllListAsync()
        {
            var orderDetails = await orderDetailRepository.GetAll().ToListAsync();

            var orderDetailsAsDto = mapper.Map<List<OrderDetailDto>>(orderDetails);

            return ServiceResult<List<OrderDetailDto>>.Success(orderDetailsAsDto);
        } 
  
        public async Task<ServiceResult<OrderDetailDto?>> GetByIdAsync(int id)
        {
            var orderDetail =await orderDetailRepository.GetByIdAsync(id);

            if (orderDetail is null)
                return ServiceResult<OrderDetailDto?>.Fail("Sipariş Detayı bulunamadi", HttpStatusCode.NotFound);

            var orderDetailAsDto = mapper.Map<OrderDetailDto>(orderDetail);

            return ServiceResult<OrderDetailDto>.Success(orderDetailAsDto)!;
        }

        public async Task<ServiceResult<CreateOrderDetailResponse>> CreateAsync(CreateOrderDetailRequest request)
        {
            var orderDetail =mapper.Map<OrderDetail>(request);

            await orderDetailRepository.AddAsync(orderDetail);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateOrderDetailResponse>.SuccessAsCreated(new CreateOrderDetailResponse(orderDetail.Id),$"api/orderdetails/{orderDetail.Id}");
        }

        public async Task<ServiceResult> UpdateAsync(int id,UpdateOrderDetailRequest request)
        {
            var orderDetail=await orderDetailRepository.GetByIdAsync(id);

            if (orderDetail is null)
                return ServiceResult.Fail("Sipariş Detayi bulunamadı", HttpStatusCode.NotFound);

            orderDetail = mapper.Map(request, orderDetail);

            orderDetailRepository.Update(orderDetail);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var orderDetail = await orderDetailRepository.GetByIdAsync(id);

            if (orderDetail is null)
                return ServiceResult.Fail("Sipariş Detayi bulunamadı", HttpStatusCode.NotFound);

            orderDetail.IsDeleted=true;
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

    }
}
