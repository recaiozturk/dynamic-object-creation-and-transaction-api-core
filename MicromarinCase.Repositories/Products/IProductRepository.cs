

namespace MicromarinCase.Repositories.Products
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<Product?> GetProdcutWithOrderDetailsAsync(int id);
    }
}
