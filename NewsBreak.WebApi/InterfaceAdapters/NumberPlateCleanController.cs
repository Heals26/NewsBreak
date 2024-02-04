using CleanArchitecture.Mediator;
using NewsBreak.Application.UseCases.NumberPlates.CreateNumberPlate;

namespace NewsBreak.WebApi.InterfaceAdapters
{

    public class NumberPlateCleanController : BaseCleanController
    {

        #region Constructors

        public NumberPlateCleanController(IUseCaseInvoker useCaseInvoker) : base(useCaseInvoker) { }

        #endregion Constructors

        #region Number Plates

        public Task CreateNumberPlate(CreateNumberPlateInputPort inputPort, ICreateNumberPlateOutputPort outputPort, CancellationToken cancellationToken)
            => this.UseCaseInvoker.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        #endregion Number Plates

    }

}
