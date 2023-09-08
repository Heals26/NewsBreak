using AutoMapper;
using CleanArchitecture.Mediator;
using NewsBreak.Application.Services.Gateways;
using NewsBreak.Application.Services.Gateways.LifxDtos;

namespace NewsBreak.Application.UseCases.Lifx.SetState
{

    public class SetStateInteractor : IUseCaseInteractor<SetStateInputPort, ISetStateOutputPort>
    {

        #region Fields

        private readonly ILifxGateway m_Gateway;
        private readonly IMapper m_Mapper;

        #endregion Fields

        #region Constructors

        public SetStateInteractor(ILifxGateway gateway, IMapper mapper)
        {
            this.m_Gateway = gateway ?? throw new ArgumentNullException(nameof(gateway));
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #endregion Constructors

        #region Methods

        Task IUseCaseInteractor<SetStateInputPort, ISetStateOutputPort>.HandleAsync(SetStateInputPort inputPort, ISetStateOutputPort outputPort, CancellationToken cancellationToken)
        {
            _ = this.m_Gateway.SetState(this.m_Mapper.Map<LifxStateDto>(inputPort), cancellationToken);
            return Task.CompletedTask;
        }

        #endregion Methods

    }

}
