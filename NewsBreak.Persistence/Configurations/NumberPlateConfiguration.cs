using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsBreak.Domain.Entities;

namespace NewsBreak.Persistence.Configurations
{

    public class NumberPlateConfiguration : IEntityTypeConfiguration<NumberPlate>
    {

        #region Methods

        public void Configure(EntityTypeBuilder<NumberPlate> entity)
        {
            _ = entity.ToTable(nameof(NumberPlate));

            _ = entity.HasKey(e => e.NumberPlateID);
            _ = entity.Property(e => e.NumberPlateID)
                .ValueGeneratedOnAdd();

            _ = entity.Property(e => e.CarType)
                .HasMaxLength(200)
                .IsRequired();

            _ = entity.Property(e => e.DateCreatedUtc)
                .IsRequired();

            _ = entity.Property(e => e.MapFriendlyAddress)
                .HasMaxLength(100)
                .IsRequired(false);

            _ = entity.Property(e => e.Registration)
                .HasMaxLength(10)
                .IsRequired();
        }

        #endregion Methods

    }

}
