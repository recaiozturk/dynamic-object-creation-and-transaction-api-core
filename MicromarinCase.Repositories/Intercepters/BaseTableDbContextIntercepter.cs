
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MicromarinCase.Repositories.Intercepters
{
    //BaseClass imizdaki CreadetDate ve UpdatedDate otomatik olarak güncellemek için
    public class BaseTableDbContextIntercepter:SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContext, BaseTable>> Behaviours = new()
        {
            {EntityState.Added,AddBehaviour },
            {EntityState.Modified,ModifiedBehaviour}
        };
        private static void AddBehaviour(DbContext context, BaseTable auditEntity)
        {
            auditEntity.CreatedDate=DateTime.Now;
            context.Entry(auditEntity).Property(x=>x.UpdatedDate).IsModified=false;
        }

        private static void ModifiedBehaviour(DbContext context, BaseTable auditEntity)
        {
            context.Entry(auditEntity).Property(x => x.CreatedDate).IsModified = false; 
            auditEntity.UpdatedDate = DateTime.Now;           
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = new CancellationToken())
        {

            foreach (var entityEntry  in eventData.Context!.ChangeTracker.Entries().ToList())
            {
                if (entityEntry.Entity is not BaseTable auditEntity)
                    continue;

                Behaviours[entityEntry.State](eventData.Context, auditEntity);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
