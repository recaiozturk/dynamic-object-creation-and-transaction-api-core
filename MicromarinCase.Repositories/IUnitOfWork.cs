

namespace MicromarinCase.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync();
    }
}
