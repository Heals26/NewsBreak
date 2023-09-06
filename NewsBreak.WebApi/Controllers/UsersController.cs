using AutoMapper;
using CleanArchitecture.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsBreak.Application.UseCases.Users.CreateUser;
using NewsBreak.WebApi.UseCases.Users.CreateUser;
using System.Net;

namespace NewsBreak.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class UsersController : BaseController
    {

        #region Controllers
        public UsersController() { }

        #endregion Controllers

        #region Accounts

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateUserAsync([FromBody]CreateUserApiRequest request)
        {
            var _Input = this.Mapper.Map<CreateUserInputPort>(request);
            //var _Presenter = await this.UseCaseInvoker.InvokeUseCaseAsync(_Input, ICreateUserOutputPort, new CancellationToken());
            return this.BadRequest();
            //return this.CreatedAtAction(nameof(CreateUserAsync), _Presenter.UserID);
        }

        #endregion Accounts

    }

}
