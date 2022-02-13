using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Persistence.Configurations
{
    public class ClientApplicationScopeConfiguration : IEntityTypeConfiguration<ClientApplicationScope>
    {

        #region Interface Implementation

        public void Configure(EntityTypeBuilder<ClientApplicationScope> entity)
        {
            // Might have to have a shadow property here
            entity.HasOne(e => e.ClientApplication)
                .WithOne();

            entity.HasOne(e => e.Scope)
                .WithOne();
        }

        #endregion Interface Implementation

    }

}
