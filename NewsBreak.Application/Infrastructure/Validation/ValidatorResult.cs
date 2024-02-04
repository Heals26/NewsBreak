using CleanArchitecture.Mediator;
using FluentValidation.Results;
using System.Linq.Expressions;

namespace NewsBreak.Application.Infrastructure.Validation
{

    public class ValidatorResult : ValidationResult, IValidationResult
    {

        #region - - - - - - Properties - - - - - -

        public new string[] RuleSetsExecuted
        {
            get => base.RuleSetsExecuted;
            set => SetRuleSetsExecuted(this, value);
        }

        #endregion Properties

        #region - - - - - - Constructors - - - - - -

        private ValidatorResult() : base() { }

        public ValidatorResult(IEnumerable<ValidationFailure> failures) : base(failures) { }

        public ValidatorResult(ValidationResult validationResult) : base(validationResult.Errors)
            => this.RuleSetsExecuted = validationResult.RuleSetsExecuted;

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public static ValidatorResult Failure(string failure)
            => Failure(new[] { new ValidationFailure(null, failure) });

        public static ValidatorResult Failure(IEnumerable<ValidationFailure> failures)
            => new ValidatorResult(failures);

        private static void SetRuleSetsExecuted(ValidatorResult validationResult, string[] value)
        {
            if (s_SetRuleSetsExecutedAction == null)
            {
                var _ValidationResultParameterExpression = Expression.Parameter(typeof(ValidationResult));
                var _ValueParameterExpression = Expression.Parameter(typeof(string[]));
                var _PropertyExpression = Expression.Property(_ValidationResultParameterExpression, nameof(RuleSetsExecuted));
                var _PropertyAssignExpression = Expression.Assign(_PropertyExpression, _ValueParameterExpression);
                var _LambdaExpression = Expression.Lambda<Action<ValidationResult, string[]>>(_PropertyAssignExpression, _ValidationResultParameterExpression, _ValueParameterExpression);

                s_SetRuleSetsExecutedAction = _LambdaExpression.Compile();
            }

            s_SetRuleSetsExecutedAction.Invoke(validationResult, value);
        }

        private static Action<ValidationResult, string[]> s_SetRuleSetsExecutedAction;

        public static ValidatorResult Success()
            => new ValidatorResult();

        #endregion Methods

    }

}
