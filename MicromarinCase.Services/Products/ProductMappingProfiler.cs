using MicromarinCase.Repositories.Products;
using MicromarinCase.Services.Products.Create;
using MicromarinCase.Services.Products.Update;
using AutoMapper;

namespace MicromarinCase.Services.Products
{
    public class OrderMappingProfiler : Profile
    {
        public OrderMappingProfiler()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, ProductWithOrderDetailDto>().ReverseMap();

            CreateMap<CreateProductRequest, Product>().ReverseMap();

            CreateMap<UpdateProductRequest, Product>().ReverseMap();
        }
    }
}
