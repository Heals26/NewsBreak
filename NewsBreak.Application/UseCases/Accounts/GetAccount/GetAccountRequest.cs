using MediatR;

namespace NewsBreak.Application.UseCases.Accounts.GetAccount
{

    public class GetAccountRequest : IRequest<GetAccountResponse>
    {

        #region Properties

        public long AccountID { get; set; }

        #endregion Properties

    }

}
