
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicromarinCase.Services.Products;
using System.Reflection;
using FluentValidation.AspNetCore;
using FluentValidation;
using MicromarinCase.Services.ExceptionHandler;
using MicromarinCase.Services.Orders;
using MicromarinCase.Services.OrderDetails;
using MicromarinCase.Services.Customers;

namespace MicromarinCase.Services.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //sirasi onemli
            services.AddExceptionHandler<CriticalExeptionHandler>();
            services.AddExceptionHandler<GlobalExeptionHandler>();

            return services;
        }
    }
}
