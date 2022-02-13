using Microsoft.EntityFrameworkCore;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Application.Services.Data
{

    public interface IBreakDBContext
    {

        DbSet<Account> Accounts { get; set; }
        DbSet<ClientApplication> ClientApplications { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }

}
