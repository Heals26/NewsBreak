using MediatR;
using NewsBreak.Application.Services.Pipelines;

namespace NewsBreak.Application.Infrastructure.Pipeline
{

    public class BusinessRuleValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IBusinessRuleValidator<TRequest>> m_Validators;

        public BusinessRuleValidationBehaviour(IEnumerable<IBusinessRuleValidator<TRequest>> validators)
        {
            this.m_Validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Task.WaitAll(this.m_Validators.Select(p => p.Evaluate(request)).ToArray(), cancellationToken);

            return next();
        }

    }

}
