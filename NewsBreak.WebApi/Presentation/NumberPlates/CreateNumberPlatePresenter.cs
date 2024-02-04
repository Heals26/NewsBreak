using AutoMapper;
using NewsBreak.Application.UseCases.NumberPlates.CreateNumberPlate;
using NewsBreak.WebApi.Services.OutputPortPresenters;
using NewsBreak.WebApi.UseCases.NumberPlates.CreateNumberPlate;

namespace NewsBreak.WebApi.Presentation.NumberPlates
{

    public class CreateNumberPlatePresenter : OutputPortPresenter, ICreateNumberPlateOutputPort
    {

        #region Constructors

        public CreateNumberPlatePresenter(IMapper mapper) : base(mapper) { }

        #endregion Constructors

        #region Methods

        Task ICreateNumberPlateOutputPort.PresentNumberPlateRegistered(long numberPlateID, CancellationToken cancellationToken)
            => this.CreatedAsync(numberPlateID, new CreateNumberPlateApiResponse() { NumberPlateID = numberPlateID }, cancellationToken);

        #endregion Methods

    }

}
