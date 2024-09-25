
using Microsoft.EntityFrameworkCore;

namespace MicromarinCase.Repositories.Customers
{
    public class CustomerRepository(AppDbContext context) : GenericRepository<Customer>(context), ICustomerRepository
    {
        public async Task<Customer?> GetCustomerWithOrdersAsync(int id)
        {
            return await context.Customers.Include(c => c.Orders).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
