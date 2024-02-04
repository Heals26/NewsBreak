using CleanArchitecture.Mediator;
using NewsBreak.Application.Services.Persistence;
using NewsBreak.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NewsBreak.Application.UseCases.Users.DeleteUser
{

    public class DeleteUserInteractor : IUseCaseInteractor<DeleteUserInputPort, IDeleteUserOutputPort>
    {

        #region Fields

        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region Constructors

        public DeleteUserInteractor(IPersistenceContext dbContext)
        {
            this.m_PersistenceContext = dbContext;
        }

        #endregion Constructors

        #region Methods

        Task IUseCaseInteractor<DeleteUserInputPort, IDeleteUserOutputPort>.HandleAsync(DeleteUserInputPort inputPort, IDeleteUserOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _User = this.m_PersistenceContext.GetEntities<User>().Single(u => u.UserID == inputPort.UserID);
            if (_User == null)
                outputPort.UserNotFound(cancellationToken);
            this.m_PersistenceContext.Remove(_User);

            return outputPort.DeleteUserSuccess(cancellationToken);
        }

        #endregion Methods

    }

}
