using Microsoft.EntityFrameworkCore;
using NewsBreak.Application.Services.Persistence;

namespace NewsBreak.Persistence.Data
{

    public class PersistenceContext : DbContext, IDbContext
    {

        #region Constructors

        public PersistenceContext(DbContextOptions<PersistenceContext> options)
            : base(options) { }

        #endregion Constructors

        #region Methods

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity Find<TEntity>(object entityID, params object[] additionalEntityIDs) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetEntities<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion Methods

    }

}
