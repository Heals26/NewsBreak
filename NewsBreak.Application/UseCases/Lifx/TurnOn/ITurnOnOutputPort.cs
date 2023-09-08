using CleanArchitecture.Mediator;

namespace NewsBreak.Application.UseCases.Lifx.TurnOn
{

    public interface ITurnOnOutputPort : IAuthenticationOutputPort
    {

        #region Properties

        Task PresentLightsTurnedOn(CancellationToken cancellationToken);
        Task PresentLightsNotFound(CancellationToken cancellationToken);

        #endregion Properties

    }

}
