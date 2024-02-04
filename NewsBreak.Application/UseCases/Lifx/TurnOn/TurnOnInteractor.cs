using CleanArchitecture.Mediator;
using NewsBreak.Application.Services.Gateways;

namespace NewsBreak.Application.UseCases.Lifx.TurnOn
{

    public class TurnOnInteractor : IUseCaseInteractor<TurnOnInputPort, ITurnOnOutputPort>
    {

        #region Fields

        private readonly ILifxGateway m_Gateway;

        #endregion Fields

        #region Constructors

        public TurnOnInteractor(ILifxGateway gateway)
            => this.m_Gateway = gateway ?? throw new ArgumentNullException(nameof(gateway));

        #endregion Constructors

        #region Methods

        Task IUseCaseInteractor<TurnOnInputPort, ITurnOnOutputPort>.HandleAsync(TurnOnInputPort turnOnInputPort, ITurnOnOutputPort outputPort, CancellationToken cancellationToken)
            => this.m_Gateway.TurnOn(cancellationToken);

        #endregion Methods

    }

}
