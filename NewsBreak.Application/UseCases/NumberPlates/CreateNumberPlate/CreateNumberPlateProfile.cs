using AutoMapper;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Application.UseCases.NumberPlates.CreateNumberPlate
{

    public class CreateNumberPlateProfile : Profile
    {

        #region Constructors

        public CreateNumberPlateProfile()
        {
            _ = this.CreateMap<CreateNumberPlateInputPort, NumberPlate>()
                .ForMember(d => d.DateCreatedUtc, o => o.MapFrom((s, d) => s.DateCreatedUtc ?? DateTime.UtcNow));
        }

        #endregion Constructors

    }

}
