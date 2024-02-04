namespace NewsBreak.Application.Services.Validation
{

    public interface IEntityExistenceChecker
    {

        #region - - - - - - Methods - - - - - -

        bool DoesEntityExist<TEntity>(object entityID, params object[] additionalEntityIDs) where TEntity : class;

        #endregion Methods
    }

}
