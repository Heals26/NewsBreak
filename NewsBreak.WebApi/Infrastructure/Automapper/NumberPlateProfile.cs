using AutoMapper;
using NewsBreak.Application.UseCases.NumberPlates.CreateNumberPlate;
using NewsBreak.WebApi.UseCases.NumberPlates.CreateNumberPlate;

namespace NewsBreak.WebApi.Infrastructure.Automapper
{

    public class NumberPlateProfile : Profile
    {

        #region Constructors

        public NumberPlateProfile()
        {
            _ = this.CreateMap<CreateNumberPlateApiRequest, CreateNumberPlateInputPort>();
        }

        #endregion Constructors

    }

}
