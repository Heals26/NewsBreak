using CleanArchitecture.Mediator;
using FluentValidation.Results;
using NewsBreak.Application.Infrastructure.Validation;
using NewsBreak.Application.Services.Persistence;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Application.UseCases.Users.CreateUser
{

    public class CreateUserBusinessRuleValidator : IUseCaseBusinessRuleValidator<CreateUserInputPort, ValidatorResult>
    {

        #region Fields

        private readonly IDbContext m_PersistenceContext;

        #endregion Fields

        #region Constructors

        public CreateUserBusinessRuleValidator(IDbContext dbContext)
        {
            this.m_PersistenceContext = dbContext;
        }

        #endregion Constructors

        #region Methods

        Task<ValidatorResult> IUseCaseBusinessRuleValidator<CreateUserInputPort, ValidatorResult>.ValidateAsync(CreateUserInputPort inputPort, CancellationToken cancellationToken)
        {
            var _ValidationFailures = new List<ValidationFailure>();

            if (this.m_PersistenceContext.GetEntities<User>().Any(u => u.Email == inputPort.Email))
                _ValidationFailures.Add(new ValidationFailure(nameof(inputPort.Email), "This email is already in use, select \"Forgot Password\" if you have forgotten your password"));

            return Task.FromResult(new ValidatorResult(_ValidationFailures));
        }

        #endregion Methods

    }

}
