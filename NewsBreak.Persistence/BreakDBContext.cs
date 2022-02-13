using Microsoft.EntityFrameworkCore;
using NewsBreak.Application.Services.Data;
using NewsBreak.Domain.Entities;
using System.Collections.Concurrent;

namespace NewsBreak.Persistence
{

    public class BreakDBContext : DbContext, IBreakDBContext
    {

        private readonly ConcurrentDictionary<long, int> m_ViewsTracker = new ConcurrentDictionary<long, int>();

        public BreakDBContext(DbContextOptions<BreakDBContext> options)
            : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<ClientApplication> ClientApplications { get; set; }

        public void AddEntity<TEntity>(TEntity entity)
        {
            if (entity != null)
                this.Add(entity);
            throw new NullReferenceException();
        }

        public void AddEntities<TEntity>(TEntity entities)
        {
            if (entities != null)
                this.AddRange(entities);
            throw new NullReferenceException();
        }

        public void RemoveEntity<TEntity>(TEntity entity)
        {
            if (entity != null)
                this.Remove(entity);
            throw new NullReferenceException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BreakDBContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var _ArticleIDsAndIncrements = this.m_ViewsTracker.Where(v => v.Value != 0).ToList();
            if (!_ArticleIDsAndIncrements.Any())
                return await base.SaveChangesAsync(cancellationToken);

            using var _Transaction = this.Database.BeginTransaction();
            var _Changes = await base.SaveChangesAsync(cancellationToken);

            foreach (var _ArticleIDAndIncrement in _ArticleIDsAndIncrements)
            {
                var _ArticleID = _ArticleIDAndIncrement.Key;
                var _Increment = _ArticleIDAndIncrement.Value;

                //TODO
                // Update the view count here
            }

            _Transaction.Commit();
            return _Changes;
        }
    }

}
