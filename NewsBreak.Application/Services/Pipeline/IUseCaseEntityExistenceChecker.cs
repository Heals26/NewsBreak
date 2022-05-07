using CleanArchitecture.Mediator;

namespace NewsBreak.Application.Services.Pipeline
{

    public interface IUseCaseEntityExistenceChecker<TUseCaseInputPort, TUseCaseOutputPort> where TUseCaseInputPort : IUseCaseInputPort<TUseCaseOutputPort>
    {

        #region - - - - - - Methods - - - - - -

        Task<bool> ValidateEntitiesExistAsync(TUseCaseInputPort inputPort, TUseCaseOutputPort outputPort, CancellationToken cancellationToken);

        #endregion Methods

    }

}
