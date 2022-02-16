using MediatR;
using NewsBreak.Application.Services.Data;
using NewsBreak.Domain.Entities;
using NewsBreak.Persistence.Models;

namespace NewsBreak.Application.UseCases.Accounts.CreateAccount
{

    public class CreateAccountInteractor : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
    {

        #region Fields

        private readonly IBreakDBContext m_DbContext;

        #endregion Fields

        #region Constructors

        public CreateAccountInteractor(IBreakDBContext breakDBContext)
        {
            this.m_DbContext = breakDBContext;
        }

        #endregion Constructors

        #region Handle Implementation

        public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            var _NewAccount = new Account()
            {
                Created = DateTime.UtcNow,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = new Password(request.Password)
            };

            var _NewAccount1 = new Account()
            {
                Created = DateTime.UtcNow,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = new Password(request.Password)
            };

            this.m_DbContext.Accounts.AddRange(new List<Account>() { _NewAccount, _NewAccount1 });
            _ = await this.m_DbContext.SaveChangesAsync(cancellationToken);

            return new CreateAccountResponse() { AccountID = _NewAccount.AccountID };
        }

        #endregion Handle Implementation

    }

}
