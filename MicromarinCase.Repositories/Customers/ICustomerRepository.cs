
namespace MicromarinCase.Repositories.Customers
{
    public interface ICustomerRepository:IGenericRepository<Customer>
    {
        Task<Customer?> GetCustomerWithOrdersAsync(int id);
    }
}
