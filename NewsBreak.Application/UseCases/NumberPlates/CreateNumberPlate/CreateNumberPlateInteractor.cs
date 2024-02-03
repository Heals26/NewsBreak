using AutoMapper;
using CleanArchitecture.Mediator;
using NewsBreak.Application.Services.Persistence;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Application.UseCases.NumberPlates.CreateNumberPlate
{

    public class CreateNumberPlateInteractor : IUseCaseInteractor<CreateNumberPlateInputPort, ICreateNumberPlateOutputPort>
    {

        #region Fields

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region Constructors

        public CreateNumberPlateInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region Methods

        Task IUseCaseInteractor<CreateNumberPlateInputPort, ICreateNumberPlateOutputPort>.HandleAsync(CreateNumberPlateInputPort inputPort, ICreateNumberPlateOutputPort outputPort, CancellationToken cancellationToken)
        {
            this.m_PersistenceContext.Add(this.m_Mapper.Map<NumberPlate>(inputPort));
            _ = this.m_PersistenceContext.SaveChangesAsync(cancellationToken);

            return Task.CompletedTask;
        }

        #endregion Methods

    }

}
