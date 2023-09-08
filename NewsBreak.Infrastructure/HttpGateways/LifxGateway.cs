using NewsBreak.Application.Services.Gateways;
using NewsBreak.Application.Services.Gateways.LifxDtos;
using NewsBreak.Infrastructure.HttpClients;

namespace NewsBreak.Infrastructure.HttpGateways
{

    public class LifxGateway : ILifxGateway
    {

        #region Fields

        private readonly LifxHttpClient m_HttpClient;

        #endregion Fields

        #region Methods

        #region Constructors

        public LifxGateway(LifxHttpClient httpClient)
            => this.m_HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        #endregion Constructors

        public Task SetState(LifxStateDto lifxStateDto, CancellationToken cancellationToken)
        {
            this.m_HttpClient.
        }

        public Task TurnOn(CancellationToken cancellationToken)
        {

        }

        public Task TurnOff(CancellationToken cancellationToken)
        {

        }

        #endregion Methods

    }

}
