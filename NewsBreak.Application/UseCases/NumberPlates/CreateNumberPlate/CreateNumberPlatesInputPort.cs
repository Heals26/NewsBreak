using CleanArchitecture.Mediator;

namespace NewsBreak.Application.UseCases.NumberPlates.CreateNumberPlate
{

    public class CreateNumberPlatesInputPort : IUseCaseInputPort<ICreateNumberPlateOutputPort>
    {

        #region Properties

        public string CarType { get; set; }
        public DateTime? DateCreatedUtc { get; set; }
        public string MapFriendlyAddress { get; set; }
        public string Registration { get; set; }

        #endregion Properties

    }

}
