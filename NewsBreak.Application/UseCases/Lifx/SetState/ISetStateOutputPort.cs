using CleanArchitecture.Mediator;

namespace NewsBreak.Application.UseCases.Lifx.SetState
{

    public interface ISetStateOutputPort : IAuthenticationOutputPort
    {

        #region Methods

        Task PresentSetStateSuccess(CancellationToken cancellationToken);

        #endregion Methods

    }

}
