using MicromarinCase.Repositories.Products;
using MicromarinCase.Services.Products.Create;
using MicromarinCase.Services.Products.Update;
using AutoMapper;

namespace MicromarinCase.Services.Products
{
    public class ProductMappingProfiler : Profile
    {
        public ProductMappingProfiler()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

            //CreateMap<CreateProductRequest, Product>().ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
            CreateMap<CreateProductRequest, Product>().ReverseMap();

            CreateMap<UpdateProductRequest, Product>().ForMember(des => des.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()));
        }
    }
}
