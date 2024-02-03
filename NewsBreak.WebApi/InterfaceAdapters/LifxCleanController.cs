using CleanArchitecture.Mediator;
using NewsBreak.Application.UseCases.Lifx.SetState;

namespace NewsBreak.WebApi.InterfaceAdapters
{

    public class LifxCleanController : BaseCleanController
    {

        #region Constructors

        public LifxCleanController(IUseCaseInvoker useCaseInvoker) : base(useCaseInvoker) { }

        #endregion Constructors

        #region Lifx

        public Task SetStateAsync(SetStateInputPort inputPort, ISetStateOutputPort outputPort, CancellationToken cancellationToken)
            => this.UseCaseInvoker.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        #endregion Lifx

    }

}
