using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace NewsBreak.WebApi.Controllers
{

    public class BaseController : ControllerBase
    {

        private IMediator m_Mediator;

        public IMediator Mediator => this.m_Mediator ?? (this.m_Mediator = this.HttpContext.RequestServices.GetService<IMediator>());


    }

}
