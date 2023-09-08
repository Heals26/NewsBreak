using AutoMapper;
using NewsBreak.Application.UseCases.Lifx.SetState;
using NewsBreak.WebApi.Services.OutputPortPresenters;

namespace NewsBreak.WebApi.Presentation.Lifx
{

    public class SetStatePresenter : OutputPortPresenter, ISetStateOutputPort
    {

        #region Constructors

        public SetStatePresenter(IMapper mapper) : base(mapper) { }

        #endregion Constructors

        #region Methods

        Task ISetStateOutputPort.PresentSetStateSuccess(CancellationToken cancellationToken)
            => this.NoContentAsync(cancellationToken);

        #endregion Methods

    }

}
