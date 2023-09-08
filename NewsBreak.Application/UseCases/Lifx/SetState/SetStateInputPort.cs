using CleanArchitecture.Mediator;

namespace NewsBreak.Application.UseCases.Lifx.SetState
{

    public class SetStateInputPort : IUseCaseInputPort<ISetStateOutputPort>
    {

        #region Properties

        public string Brightness { get; set; }
        public string Color { get; set; }
        public decimal Duration { get; set; }
        public string Power { get; set; }

        #endregion Properties

    }

}
