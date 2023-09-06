using NewsBreak.Application.Infrastructure.Factories;
using NewsBreak.Application.Services.Persistence;
using NewsBreak.Application.Services.Validation;
using NewsBreak.Domain.Enumerations;

namespace NewsBreak.Application.Infrastructure.Validation
{

    public class EntityExistenceChecker : IEntityExistenceChecker
    {

        #region - - - - - - Fields - - - - - -

        private readonly IDbContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public EntityExistenceChecker(IDbContext persistenceContext)
            => this.m_PersistenceContext = persistenceContext;

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        bool IEntityExistenceChecker.DoesEntityExist<TEntity>(object entityID, params object[] additionalEntityIDs)
        {
            if (typeof(TEntity).IsSubclassOf(typeof(Enumeration)))
                return DelegateFactory.GetFunction<object, bool>(typeof(EnumerationExistenceFactory<>).MakeGenericType(typeof(TEntity)))?.Invoke(entityID) ?? false;

            return this.m_PersistenceContext.Find<TEntity>(entityID, additionalEntityIDs) != null;
        }

        #endregion Methods

        #region - - - - - - Nested Classes - - - - - -

        private class EnumerationExistenceFactory<TEntity>
            : IDelegateFactory<object, bool>
            where TEntity : Enumeration
        {

            #region - - - - - - Methods - - - - - -

            public Func<object, bool> GetFunction()
                => eob => Enumeration.GetAll<TEntity>().Any(e => Equals(e.Value, eob));

            #endregion Methods

        }

        #endregion Nested Classes

    }

}
