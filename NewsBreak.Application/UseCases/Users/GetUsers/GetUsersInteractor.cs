using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Mediator;
using NewsBreak.Application.Dtos.Users;
using NewsBreak.Application.Services.Persistence;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Application.UseCases.Users.GetUsers
{

    public class GetUsersInteractor : IUseCaseInteractor<GetUsersInputPort, IGetUsersOutputPort>
    {

        #region Fields

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region Constructors

        public GetUsersInteractor(IPersistenceContext dbContext, IMapper mapper)
        {
            this.m_Mapper = mapper;
            this.m_PersistenceContext = dbContext;
        }

        #endregion Constructors

        #region Methods

        Task IUseCaseInteractor<GetUsersInputPort, IGetUsersOutputPort>.HandleAsync(GetUsersInputPort inputPort, IGetUsersOutputPort outputPort, CancellationToken cancellationToken)
            => outputPort.PresentUsersAsync(this.m_PersistenceContext.GetEntities<User>()
                .ProjectTo<UserDto>(this.m_Mapper.ConfigurationProvider), cancellationToken);

        #endregion Methods

    }

}
