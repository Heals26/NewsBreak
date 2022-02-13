using AutoMapper;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Application.UseCases.Accounts.GetAccount
{

    public class GetAccountProfile : Profile
    {

        #region Constructors
        
        public GetAccountProfile()
        {
            this.CreateMap<Account, GetAccountResponse>();
        }

        #endregion Constructors

    }

}
