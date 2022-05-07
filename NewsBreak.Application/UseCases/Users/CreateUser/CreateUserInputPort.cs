using CleanArchitecture.Mediator;

namespace NewsBreak.Application.UseCases.Users.CreateUser
{

    public class CreateUserInputPort : IUseCaseInputPort<ICreateUserOutputPort>
    {

        #region Properties

        public DateTime CreatedOnUTC { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        #endregion Properties

    }

}
