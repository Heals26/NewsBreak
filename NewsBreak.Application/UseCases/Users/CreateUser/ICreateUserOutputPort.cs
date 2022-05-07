using CleanArchitecture.Mediator;
using NewsBreak.Application.Dtos.Users;
using NewsBreak.Application.Infrastructure.Validation;

namespace NewsBreak.Application.UseCases.Users.CreateUser
{

    public interface ICreateUserOutputPort : IBusinessRuleValidationOutputPort<ValidatorResult>, IValidationOutputPort<ValidatorResult>
    {

        Task PresentCreatedUserAsync(long userID, CancellationToken cancellationToken);

        Task PresentUserExistsBusinessRuleViolationAsync(string userEmail, CancellationToken cancellationToken);

    }

}
