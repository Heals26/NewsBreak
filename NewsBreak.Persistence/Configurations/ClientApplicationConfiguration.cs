using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Persistence.Configurations
{

    public class ClientApplicationConfiguration : IEntityTypeConfiguration<ClientApplication>
    {

        #region IEntityTypeConfiguration Implementation

        public void Configure(EntityTypeBuilder<ClientApplication> entity)
        {
            entity.HasKey(e => e.ClientApplicationID);
            entity.Property(e => e.ClientApplicationID)
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Name)
                .IsRequired();

            entity.Property(e => e.Secret)
                .IsRequired();

            entity.HasMany(e => e.ClientApplicationScopes)
                .WithOne(e => e.ClientApplication);
            entity.Property(e => e.ClientApplicationScopes)
                .IsRequired(false);
        }

        #endregion IEntityTypeConfiguration Implementation

    }

}
