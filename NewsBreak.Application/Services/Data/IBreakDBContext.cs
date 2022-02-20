using Microsoft.EntityFrameworkCore;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Application.Services.Data
{

    public interface IBreakDBContext
    {

        DbSet<Account> Accounts { get; set; }
        DbSet<ClientApplication> ClientApplications { get; set; }

        void AddEntity<TEntity>(TEntity entity);
        void AddEntities<TEntity>(TEntity entities);
        void RemoveEntity<TEntity>(TEntity entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }

}
