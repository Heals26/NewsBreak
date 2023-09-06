using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBreak.Application.UseCases.Users.DeleteUser
{

    public interface IDeleteUserOutputPort
    {

        Task DeleteUserSuccess(CancellationToken cancellationToken);
        Task UserNotFound(CancellationToken cancellationToken);


    }

}
