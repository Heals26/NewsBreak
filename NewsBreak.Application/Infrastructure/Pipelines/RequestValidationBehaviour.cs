using FluentValidation;
using MediatR;

namespace NewsBreak.Application.Infrastructure.Pipelines
{

    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> m_Validators;

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.m_Validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var _ValidationContext = new ValidationContext<TRequest>(request);

            var _Failures = this.m_Validators
                .Select(v => v.Validate(_ValidationContext))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (_Failures.Any())
                throw new ValidationException(_Failures);

            return next();
        }

    }

}
