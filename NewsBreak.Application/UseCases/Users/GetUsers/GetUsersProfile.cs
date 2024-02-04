using AutoMapper;
using NewsBreak.Application.Dtos.Users;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Application.UseCases.Users.GetUsers
{

    public class GetUsersProfile : Profile
    {

        #region Constructors

        public GetUsersProfile()
        {
            this.CreateMap<User, UserDto>();
        }

        #endregion Constructors

    }

}
