using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Persistence.Configurations
{

    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {

        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.HasKey(c => c.AccountID);

            entity.Property(c => c.AccountID)
                .ValueGeneratedOnAdd();

            entity.Property(c => c.Email)
                .IsRequired();

            entity.OwnsOne(c => c.Password, password =>
            {
                password.Property<string>("m_Password")
                .IsRequired();
            });
        }

    }

}
