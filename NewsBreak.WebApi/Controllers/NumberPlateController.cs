using Microsoft.AspNetCore.Mvc;
using NewsBreak.Application.UseCases.NumberPlates.CreateNumberPlate;
using NewsBreak.WebApi.InterfaceAdapters;
using NewsBreak.WebApi.Presentation.NumberPlates;
using NewsBreak.WebApi.UseCases.NumberPlates.CreateNumberPlate;

namespace NewsBreak.WebApi.Controllers
{

    [Route("[controller]")]
    public class NumberPlateController : BaseController
    {

        #region Fields

        private readonly NumberPlateCleanController m_NumberPlateCleanController;

        #endregion Fields

        #region Constructors

        public NumberPlateController(NumberPlateCleanController numberPlateCleanController)
        {
            this.m_NumberPlateCleanController = numberPlateCleanController ?? throw new ArgumentNullException(nameof(numberPlateCleanController));
        }

        #endregion Constructors

        #region Plates

        [HttpPost]
        public async Task<IActionResult> CreateNumberPlate([FromServices] CreateNumberPlatePresenter presenter, [FromBody] CreateNumberPlateApiRequest body)
        {
            await this.m_NumberPlateCleanController.CreateNumberPlate(this.Mapper.Map<CreateNumberPlateInputPort>(body), presenter, CancellationToken.None);

            return presenter.Result;
        }

        #endregion Plates

    }

}
