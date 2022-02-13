using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Persistence.Configurations
{
    public class ScopeConfiguration : IEntityTypeConfiguration<Scope>
    {

        #region Interface Implementation

        public void Configure(EntityTypeBuilder<Scope> entity)
        {
            entity.HasKey(e => e.ScopeID);
            entity.Property(e => e.ScopeID)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .IsRequired();
        }

        #endregion Interface Implementation

    }

}
