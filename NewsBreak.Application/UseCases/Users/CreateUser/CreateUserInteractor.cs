using AutoMapper;
using CleanArchitecture.Mediator;
using NewsBreak.Application.Services.Persistence;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Application.UseCases.Users.CreateUser
{

    public class CreateUserInteractor : IUseCaseInteractor<CreateUserInputPort, ICreateUserOutputPort>
    {

        #region Fields

        private readonly IDbContext m_PersistenceContext;
        private readonly IMapper m_Mapper;

        #endregion Fields

        #region Constructors

        public CreateUserInteractor(IDbContext dbContext, IMapper mapper)
        {
            this.m_PersistenceContext = dbContext;
            this.m_Mapper = mapper;
        }

        #endregion Constructors

        #region Methods

        Task IUseCaseInteractor<CreateUserInputPort, ICreateUserOutputPort>.HandleAsync(CreateUserInputPort inputPort, ICreateUserOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _User = this.m_Mapper.Map<User>(inputPort);
            this.m_PersistenceContext.Add(_User);

            return outputPort.PresentCreatedUserAsync(_User.UserID, cancellationToken);
        }

        #endregion Methods

    }

}
