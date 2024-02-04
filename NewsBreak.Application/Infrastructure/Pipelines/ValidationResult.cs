using CleanArchitecture.Mediator;
using FluentValidation.Results;
using System.Linq.Expressions;

namespace NewsBreak.Application.Infrastructure.Pipelines
{

    // There might be a conflict between the new ValidationResult and the FluentValidation Result
    public class ValidationResult : FluentValidation.Results.ValidationResult, IValidationResult
    {

        #region - - - - - - Fields - - - - - -

        private static Action<ValidationResult, string[]> s_SetRuleSetsExecutedAction;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        private ValidationResult() : base() { }

        public ValidationResult(IEnumerable<ValidationFailure> failures) : base(failures) { }

        public ValidationResult(ValidationResult validationResult) : base(validationResult.Errors)
            => this.RuleSetsExecuted = validationResult.RuleSetsExecuted;

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        public new string[] RuleSetsExecuted
        {
            get => base.RuleSetsExecuted;
            set => SetRuleSetsExecuted(this, value);
        }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        private static void SetRuleSetsExecuted(ValidationResult validationResult, string[] value)
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

        public static ValidationResult Success()
            => new();

        #endregion Methods

    }

}
