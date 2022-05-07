using CleanArchitecture.Mediator;
using CleanArchitecture.Mediator.Infrastructure;
using CleanArchitecture.Mediator.Pipeline;
using NewsBreak.Application.Infrastructure.Factories;
using NewsBreak.Application.Services.Pipeline;

namespace NewsBreak.Application.Infrastructure.Pipeline
{

    internal class EntityExistenceCheckerPipe : IUseCasePipe
    {

        #region - - - - - - Fields - - - - - -

        private readonly UseCaseServiceResolver m_ServiceResolver;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public EntityExistenceCheckerPipe(UseCaseServiceResolver serviceResolver)
            => this.m_ServiceResolver = serviceResolver ?? throw new ArgumentNullException(nameof(serviceResolver));

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        async Task IUseCasePipe.HandleAsync<TUseCaseInputPort, TUseCaseOutputPort>(
            TUseCaseInputPort inputPort,
            TUseCaseOutputPort outputPort,
            UseCasePipeHandleAsync nextUseCasePipeHandle,
            CancellationToken cancellationToken)
        {
            if (await DelegateFactory.GetFunction<(UseCaseServiceResolver, TUseCaseInputPort, TUseCaseOutputPort, CancellationToken), Task<bool>>(typeof(EntityExistenceCheckerFactory<,>)
                .MakeGenericType(typeof(TUseCaseInputPort), typeof(TUseCaseOutputPort)))?
                    .Invoke((this.m_ServiceResolver, inputPort, outputPort, cancellationToken)))
                await nextUseCasePipeHandle().ConfigureAwait(false);
        }

        #endregion Methods

        #region - - - - - - Nested Classes - - - - - -

        private class EntityExistenceCheckerFactory<TUseCaseInputPort, TUseCaseOutputPort> :
            IDelegateFactory<(UseCaseServiceResolver, TUseCaseInputPort, TUseCaseOutputPort, CancellationToken), Task<bool>> where TUseCaseInputPort : IUseCaseInputPort<TUseCaseOutputPort>
        {

            #region - - - - - - Methods - - - - - -

            public Func<(UseCaseServiceResolver, TUseCaseInputPort, TUseCaseOutputPort, CancellationToken), Task<bool>> GetFunction()
                => sripopc
                    => sripopc.Item1
                        .GetService<IUseCaseEntityExistenceChecker<TUseCaseInputPort, TUseCaseOutputPort>>()?
                        .ValidateEntitiesExistAsync(sripopc.Item2, sripopc.Item3, sripopc.Item4)
                            ?? Task.FromResult(true);

            #endregion Methods

        }

        #endregion Nested Classes

    }

}
