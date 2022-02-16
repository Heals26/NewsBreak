using MediatR;

namespace NewsBreak.Application.UseCases.Accounts.CreateAccount
{

    public class CreateAccountRequest : IRequest<CreateAccountResponse>
    {

        #region Properties

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        #endregion Properties

    }

}
