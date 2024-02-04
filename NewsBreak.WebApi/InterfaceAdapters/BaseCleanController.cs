using CleanArchitecture.Mediator;

namespace NewsBreak.WebApi.InterfaceAdapters
{

    public class BaseCleanController
    {

        #region - - - - - - Constructors - - - - - -

        public BaseCleanController(IUseCaseInvoker useCaseInvoker)
            => this.UseCaseInvoker = useCaseInvoker ?? throw new ArgumentNullException(nameof(useCaseInvoker));

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        protected IUseCaseInvoker UseCaseInvoker { get; }

        #endregion Properties

    }

}
