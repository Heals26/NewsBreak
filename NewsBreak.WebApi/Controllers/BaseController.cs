using AutoMapper;
using CleanArchitecture.Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NewsBreak.WebApi.Controllers
{

    public class BaseController : ControllerBase
    {

        #region Fields

        private readonly IMapper m_Mapper;
        private readonly IUseCaseInvoker m_UseCaseInvoker;

        #endregion Fields

        #region Properties

        public IMapper Mapper => this.m_Mapper;
        public IUseCaseInvoker UseCaseInvoker => this.m_UseCaseInvoker;

        #endregion Properties

        #region Constructors

        public BaseController() { }

        public BaseController(IMapper mapper, IUseCaseInvoker useCaseInvoker)
        {
            this.m_Mapper = mapper;
            this.m_UseCaseInvoker = useCaseInvoker;
        }

        #endregion Constructors

    }

}
