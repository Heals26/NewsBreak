using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsBreak.Application.Services.Data
{

    public interface IBreakDBContext
    {

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }

}
