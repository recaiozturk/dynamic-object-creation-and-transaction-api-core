
using MicromarinCase.Services.Customers.Create;
using MicromarinCase.Services.Customers.Update;

namespace MicromarinCase.Services.Customers
{
    public interface ICustomerService
    {
        Task<ServiceResult<List<CustomerDto>>> GetAllListAsync();
        Task<ServiceResult<CustomerDto?>> GetByIdAsync(int id);
        Task<ServiceResult<CreateCustomerResponse>> CreateAsync(CreateCustomerRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateCustomerRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
