using CleanArchitecture.Mediator;
using NewsBreak.Application.UseCases.Lifx.SetState;

namespace NewsBreak.WebApi.InterfaceAdapters
{

    public class LifxController : BaseCleanController
    {

        #region Constructors

        public LifxController(IUseCaseInvoker useCaseInvoker) : base(useCaseInvoker) { }

        #endregion Constructors

        #region Lifx

        public Task SetStateAsync(SetStateInputPort inputPort, ISetStateOutputPort outputPort, CancellationToken cancellationToken)
            => this.UseCaseInvoker.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        #endregion Lifx

    }

}
