using FluentValidation;
using NewsBreak.Application.Infrastructure.Validation;

namespace NewsBreak.Application.UseCases.Users.CreateUser
{

    public class CreateUserInputPortValidator : BaseValidator<CreateUserInputPort>
    {

        #region Constructors

        public CreateUserInputPortValidator()
        {
            _ = this.RuleFor(r => r.Email).EmailAddress();
            _ = this.RuleFor(r => r.Password).NotEmpty();
            _ = this.RuleFor(r => r.CreatedOnUTC).NotEmpty();
            _ = this.RuleFor(r => r.FirstName).NotEmpty();
            _ = this.RuleFor(r => r.LastName).NotEmpty();
        }

        #endregion Constructors

    }

}
