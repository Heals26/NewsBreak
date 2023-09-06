using CleanArchitecture.Mediator;

namespace NewsBreak.Application.UseCases.Users.DeleteUser
{

    public class DeleteUserInputPort : IUseCaseInputPort<IDeleteUserOutputPort>
    {

        #region Properties

        public long UserID { get; set; }

        #endregion Properties

    }

}
