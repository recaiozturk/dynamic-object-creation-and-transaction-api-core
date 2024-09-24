
namespace MicromarinCase.Repositories.Customers
{
    public class CustomerRepository(AppDbContext context) : GenericRepository<Customer>(context), ICustomerRepository
    {
    }
}
