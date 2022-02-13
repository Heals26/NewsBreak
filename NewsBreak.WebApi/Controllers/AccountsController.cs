using Microsoft.AspNetCore.Mvc;
using NewsBreak.Application.UseCases.Accounts.GetAccount;
using System.Net;

namespace NewsBreak.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class AccountsController : BaseController
    {

        #region Controllers

        public AccountsController()
        {

        }

        #endregion Controllers

        #region Accounts

        [HttpGet("{accountID}")]
        [ProducesResponseType(typeof(GetAccountResponse), (int)HttpStatusCode.OK)]
        public Task<GetAccountResponse> GetAccount([FromRoute] long accountId)
            => this.Mediator.Send(new GetAccountRequest() { AccountID = accountId });

        #endregion Accounts

    }

}
