using AutoMapper;
using CleanArchitecture.Mediator;
using Microsoft.AspNetCore.Mvc;
using NewsBreak.Application.Infrastructure.Pipelines;
using NewsBreak.WebApi.Infrastructure.ObjectResults;
using NewsBreak.WebApi.Services.ActionResults;
using System.Net;

namespace NewsBreak.WebApi.Services.OutputPortPresenters
{

    public class OutputPortPresenter :
        IAuthenticationOutputPort,
        IAuthorisationOutputPort<AuthorisationResult>,
        IBusinessRuleValidationOutputPort<ValidationResult>,
        IValidationOutputPort<ValidationResult>
    {

        #region - - - - - - Fields - - - - - -

        protected readonly IMapper m_Mapper;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public OutputPortPresenter(IMapper mapper)
            => this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        public bool PresentedSuccessfully { get; private set; }

        public IActionResult Result { get; private set; }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        protected Task AcceptedAsync<TResult>(string location, TResult result, CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            this.Result = new AcceptedResult(location, result);

            return Task.CompletedTask;
        }

        protected Task BadRequestAsync(string errorTitle, string errorMessage, CancellationToken cancellationToken)
        {
            var _Details = new ValidationProblemDetails()
            {
                Detail = "See Errors property for more details.",
                Status = (int)HttpStatusCode.BadRequest,
                Title = errorTitle,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
            };
            _Details.Errors.Add(string.Empty, new string[] { errorMessage });

            return this.BadRequestAsync(_Details, cancellationToken);
        }

        protected Task BadRequestAsync(ValidationProblemDetails validationProblemDetails, CancellationToken cancellationToken)
        {
            this.Result = new BadRequestObjectResult(validationProblemDetails);
            return Task.CompletedTask;
        }

        protected Task ConflictAsync(CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            this.Result = new ConflictResult();
            return Task.CompletedTask;
        }

        protected Task CreatedAsync<TResult>(long resourceID, TResult result, CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;

            // For the ApiAuditingActionFilterAttribute OnResultExecuted method, we require an ID for the resource.
            this.Result = new CreatedClassResource(string.Empty, resourceID, result);
            return Task.CompletedTask;
        }

        protected Task ForbiddenAsync(ProblemDetails problemDetails, CancellationToken cancellationToken)
        {
            this.Result = new ForbiddenObjectResult(problemDetails);
            return Task.CompletedTask;
        }

        Task IAuthenticationOutputPort.PresentUnauthenticatedAsync(CancellationToken cancellationToken)
            => this.UnauthorisedAsync(cancellationToken);

        Task IAuthorisationOutputPort<AuthorisationResult>.PresentUnauthorisedAsync(AuthorisationResult authorisationFailure, CancellationToken cancellationToken)
            => this.ForbiddenAsync(this.m_Mapper.Map<ProblemDetails>(authorisationFailure), cancellationToken);

        Task IBusinessRuleValidationOutputPort<ValidationResult>.PresentBusinessRuleValidationFailureAsync(ValidationResult validationFailure, CancellationToken cancellationToken)
            => this.BadRequestAsync(this.m_Mapper.Map<ValidationProblemDetails>(validationFailure), cancellationToken);

        Task IValidationOutputPort<ValidationResult>.PresentValidationFailureAsync(ValidationResult validationFailure, CancellationToken cancellationToken)
            => this.BadRequestAsync(this.m_Mapper.Map<ValidationProblemDetails>(validationFailure), cancellationToken);

        protected Task NoContentAsync(CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            this.Result = new NoContentResult();
            return Task.CompletedTask;
        }

        protected Task NotFoundAsync(string resourceName, object resource, CancellationToken cancellationToken)
            => this.NotFoundAsync($"{resourceName} ({resource}) was not found", cancellationToken);

        protected Task NotFoundAsync(string errorMessage, CancellationToken cancellationToken)
        {
            this.Result = new NotFoundObjectResult(new ProblemDetails()
            {
                Detail = errorMessage,
                Status = (int)HttpStatusCode.NotFound,
                Title = "Entity was not found.",
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
            });
            return Task.CompletedTask;
        }

        protected Task OkAsync<TResult>(TResult result, CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            this.Result = new OkObjectResult(result);
            return Task.CompletedTask;
        }

        protected Task OkAsync(Stream stream, string contentType, CancellationToken cancellationToken, string fileName = null)
        {
            this.PresentedSuccessfully = true;
            this.Result = new StreamResult(stream, contentType) { FileName = fileName };

            return Task.CompletedTask;
        }

        protected Task PaymentRequiredAsync(CancellationToken cancellationToken)
        {
            //this.PresentedSuccessfully = true;
            //this.Result = new PaymentRequiredObjectResult(new ProblemDetails()
            //{
            //    Detail = "Payment Required",
            //    Status = (int)HttpStatusCode.PaymentRequired,
            //    Title = "Payment Required",
            //    Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.2"
            //});

            return Task.CompletedTask;
        }

        //protected void ScheduleIntegrationBehaviour<THangfire, THelper>(THelper helper, CancellationToken cancellationToken) where THangfire : IHangfireGateway<THelper>
        //{
        //     TODO:
        //     Integrate hosted services
        //    var _Client = new BackgroundJobClient();
        //
        //    _ = _Client.Enqueue<THangfire>(p => p.Process(helper, cancellationToken));
        //}

        protected Task UnauthorisedAsync(CancellationToken cancellationToken)
        {
            this.Result = new UnauthorizedResult();
            return Task.CompletedTask;
        }

        protected Task UnprocessableContentAsync(string propertyName, string errorMessage, CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            this.Result = new UnprocessableEntityObjectResult(new ProblemDetails()
            {
                Detail = propertyName,
                Status = (int)HttpStatusCode.UnprocessableEntity,
                Title = errorMessage,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#autoid-78"
            });

            return Task.CompletedTask;
        }

        #endregion Methods

    }

}
