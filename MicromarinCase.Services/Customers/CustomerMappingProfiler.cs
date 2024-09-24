
using AutoMapper;
using MicromarinCase.Repositories.Customers;
using MicromarinCase.Services.Customers.Create;
using MicromarinCase.Services.Customers.Update;

namespace MicromarinCase.Services.Customers
{
    public class CustomerMappingProfiler : Profile
    {
        public CustomerMappingProfiler()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<CreateCustomerRequest, Customer>().ReverseMap();

            CreateMap<UpdateCustomerRequest, Customer>().ReverseMap();
        }
    }
}
