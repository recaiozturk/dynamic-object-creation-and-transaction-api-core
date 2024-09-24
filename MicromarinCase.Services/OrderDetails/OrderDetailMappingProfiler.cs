
using AutoMapper;
using MicromarinCase.Repositories.OrderDetails;
using MicromarinCase.Services.OrderDetails.Create;
using MicromarinCase.Services.OrderDetails.Update;

namespace MicromarinCase.Services.OrderDetails
{
    public class OrderDetailMappingProfiler : Profile
    {
        public OrderDetailMappingProfiler()
        {
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

            CreateMap<CreateOrderDetailRequest, OrderDetail>().ReverseMap();

            CreateMap<UpdateOrderDetailRequest, OrderDetail>().ReverseMap();
        }

    }
}
