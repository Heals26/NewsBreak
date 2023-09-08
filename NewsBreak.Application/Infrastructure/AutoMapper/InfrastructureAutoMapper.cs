using AutoMapper;
using NewsBreak.Application.Services.Gateways.LifxDtos;
using NewsBreak.Application.UseCases.Lifx.SetState;

namespace NewsBreak.Application.Infrastructure.AutoMapper
{

    public class InfrastructureAutoMapper : Profile
    {

        #region Constructors

        public InfrastructureAutoMapper()
        {
            _ = this.CreateMap<SetStateInputPort, LifxStateDto>();
        }

        #endregion Constructors

    }

}
