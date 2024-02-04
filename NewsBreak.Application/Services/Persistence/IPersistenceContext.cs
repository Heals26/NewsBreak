﻿namespace NewsBreak.Application.Services.Persistence
{

    public interface IPersistenceContext
    {

        #region Methods

        void Add<TEntity>(TEntity entity) where TEntity : class;
        TEntity Find<TEntity>(object entityID, params object[] additionalEntityIDs) where TEntity : class;
        IQueryable<TEntity> GetEntities<TEntity>() where TEntity : class;
        void Remove<TEntity>(TEntity entity) where TEntity : class;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        #endregion Methods

    }

}
