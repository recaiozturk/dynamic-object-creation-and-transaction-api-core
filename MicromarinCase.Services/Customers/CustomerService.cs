using MicromarinCase.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;
using MicromarinCase.Repositories.Customers;
using MicromarinCase.Services.Customers.Create;
using MicromarinCase.Services.Customers.Update;


namespace MicromarinCase.Services.Customers
{
    public class CustomerService(ICustomerRepository customerRepository,IUnitOfWork unitOfWork,IMapper mapper):ICustomerService
    {
        public async Task<ServiceResult<List<CustomerDto>>> GetAllListAsync()
        {
            var customers = await customerRepository.GetAll().ToListAsync();

            var customersAsDto = mapper.Map<List<CustomerDto>>(customers);

            return ServiceResult<List<CustomerDto>>.Success(customersAsDto);
        } 
  
        public async Task<ServiceResult<CustomerDto?>> GetByIdAsync(int id)
        {
            var customer =await customerRepository.GetByIdAsync(id);

            if (customer is null)
                return ServiceResult<CustomerDto?>.Fail("Müşteri bulunamadi", HttpStatusCode.NotFound);

            var customerAsDto = mapper.Map<CustomerDto>(customer);

            return ServiceResult<CustomerDto>.Success(customerAsDto)!;
        }

        public async Task<ServiceResult<CreateCustomerResponse>> CreateAsync(CreateCustomerRequest request)
        {
            var customer =mapper.Map<Customer>(request);

            await customerRepository.AddAsync(customer);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateCustomerResponse>.SuccessAsCreated(new CreateCustomerResponse(customer.Id),$"api/customers/{customer.Id}");
        }

        public async Task<ServiceResult> UpdateAsync(int id,UpdateCustomerRequest request)
        {
            var customer=await customerRepository.GetByIdAsync(id);

            if (customer is null)
                return ServiceResult.Fail("Müşteri bulunamadi", HttpStatusCode.NotFound);

            customer = mapper.Map(request, customer);

            customerRepository.Update(customer);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var customer = await customerRepository.GetByIdAsync(id);

            if (customer is null)
                return ServiceResult.Fail("Müşteri buluınamadı", HttpStatusCode.NotFound);

            customer.IsDeleted=true;
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

    }
}
