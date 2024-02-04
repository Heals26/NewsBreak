using NewsBreak.Application.Services.Gateways.LifxDtos;

namespace NewsBreak.Application.Services.Gateways
{

    public interface ILifxGateway
    {

        #region Methods

        Task<HttpResponseMessage> SetState(LifxStateDto lifxStateDto, CancellationToken cancellationToken);
        Task TurnOn(CancellationToken cancellationToken);
        Task TurnOff(CancellationToken cancellationToken);

        #endregion Methods

    }

}
