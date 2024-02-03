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
            => base.Add(entity);

        public TEntity Find<TEntity>(object entityID, params object[] additionalEntityIDs) where TEntity : class
            => base.Find<TEntity>(new[] { entityID }.Concat(additionalEntityIDs).ToArray());

        public IQueryable<TEntity> GetEntities<TEntity>() where TEntity : class
            => base.Set<TEntity>().AsQueryable();

        public void Remove<TEntity>(TEntity entity) where TEntity : class
            => base.Remove(entity);

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
            => base.RemoveRange();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
            => base.SaveChangesAsync(cancellationToken);

        #endregion Methods

    }

}
