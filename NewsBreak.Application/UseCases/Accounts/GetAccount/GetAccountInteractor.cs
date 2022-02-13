using AutoMapper;
using MediatR;
using NewsBreak.Application.Services.Data;

namespace NewsBreak.Application.UseCases.Accounts.GetAccount
{

    public class GetAccountInteractor : IRequestHandler<GetAccountRequest, GetAccountResponse>
    {

        #region Fields

        private readonly IBreakDBContext m_DbContext;
        private readonly IMapper m_Mapper;

        #endregion Fields

        #region Controllers
        public GetAccountInteractor(IBreakDBContext breakDBContext, IMapper mapper)
        {
            this.m_DbContext = breakDBContext;
            this.m_Mapper = mapper;
        }

        #endregion Controllers

        #region Handle

        public async Task<GetAccountResponse> Handle(GetAccountRequest request, CancellationToken cancellationToken)
        {
            var _Account = await this.m_DbContext.Accounts.FindAsync(request.AccountID);

            return this.m_Mapper.Map<GetAccountResponse>(_Account);
        }

        #endregion Handle

    }

}
