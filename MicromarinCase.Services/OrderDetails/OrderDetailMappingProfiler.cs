
using AutoMapper;
using MicromarinCase.Repositories.OrderDetails;
using MicromarinCase.Repositories.Orders;
using MicromarinCase.Services.OrderDetails;
using MicromarinCase.Services.Orders.Create;
using MicromarinCase.Services.Orders.Update;

namespace MicromarinCase.Services.Orders
{
    public class OrderDetailMappingProfiler : Profile
    {
        public OrderDetailMappingProfiler()
        {
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

            //CreateMap<CreateOrderRequest, Order>().ReverseMap();

            //CreateMap<UpdateOrdertRequest, Order>().ReverseMap();
        }
    }
}
