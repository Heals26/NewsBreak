using NewsBreak.Application.Services.Gateways;
using NewsBreak.Application.Services.Gateways.LifxDtos;

namespace NewsBreak.Infrastructure.HttpGateways
{

    public class LifxHttpGateway : ILifxGateway
    {

        #region Fields

        private const string STATE_URI = "lights/all/state";

        #endregion Fields

        #region Constructors

        public LifxHttpGateway(HttpClient httpClient)
            => this.HttpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

        #endregion Constructors

        #region Properties

        public HttpClient HttpClient { get; set; }

        #endregion Properties

        #region Methods

        public async Task<HttpResponseMessage> SetState(LifxStateDto lifxStateDto, CancellationToken cancellationToken)
        {
            var _HttpRequestMessage = new HttpRequestMessage(HttpMethod.Put, STATE_URI);

            using (var _Response = await this.HttpClient.SendAsync(_HttpRequestMessage, cancellationToken))
            {
                return _Response;
            }
        }

        public Task TurnOn(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task TurnOff(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        #endregion Methods

    }

}
