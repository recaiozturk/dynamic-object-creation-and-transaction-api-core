
using AutoMapper;
using MicromarinCase.Repositories.Orders;
using MicromarinCase.Services.Orders.Create;
using MicromarinCase.Services.Orders.Update;

namespace MicromarinCase.Services.Orders
{
    public class OrderMappingProfiler : Profile
    {
        public OrderMappingProfiler()
        {
            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<CreateOrderRequest, Order>().ReverseMap();

            CreateMap<UpdateOrdertRequest, Order>().ReverseMap();
        }
    }
}
