using CleanArchitecture.Mediator;

namespace NewsBreak.Application.UseCases.NumberPlates.CreateNumberPlate
{

    public interface ICreateNumberPlateOutputPort : IAuthenticationOutputPort
    {

        #region Methods

        Task PresentNumberPlateRegistered(long numberPlateID, CancellationToken cancellationToken);

        #endregion Methods

    }

}
