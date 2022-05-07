using CleanArchitecture.Mediator;
using FluentValidation;

namespace NewsBreak.Application.Infrastructure.Validation
{

    public abstract class BaseValidator<TInputPort> : AbstractValidator<TInputPort>, IUseCaseInputPortValidator<TInputPort, ValidatorResult>
        where TInputPort : IUseCaseInputPort<IValidationOutputPort<ValidatorResult>>
    {

        #region Methods

        Task<ValidatorResult> IUseCaseInputPortValidator<TInputPort, ValidatorResult>.ValidateAsync(TInputPort inputPort, CancellationToken cancellationToken)
            => Task.FromResult(new ValidatorResult(this.Validate(inputPort)));

        #endregion Methods

    }

}
