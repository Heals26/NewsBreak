namespace NewsBreak.Application.Services.Pipelines
{

    public interface IBusinessRuleValidator<TRequest>
    {

        Task Evaluate(TRequest request);

    }

}
