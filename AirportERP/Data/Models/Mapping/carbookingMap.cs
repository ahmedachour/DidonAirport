using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class carbookingMap : EntityTypeConfiguration<carbooking>
    {
        public carbookingMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idCar, t.idPasssenger });

            // Properties
            this.Property(t => t.idCar)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idPasssenger)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("carbooking", "didon_db");
            this.Property(t => t.idCar).HasColumnName("idCar");
            this.Property(t => t.idPasssenger).HasColumnName("idPasssenger");
            this.Property(t => t.endDate).HasColumnName("endDate");
            this.Property(t => t.priceOfRent).HasColumnName("priceOfRent");
            this.Property(t => t.startDate).HasColumnName("startDate");
            this.Property(t => t.idPassenger).HasColumnName("idPassenger");

            // Relationships
            this.HasRequired(t => t.car)
                .WithMany(t => t.carbookings)
                .HasForeignKey(d => d.idCar);
            this.HasOptional(t => t.user)
                .WithMany(t => t.carbookings)
                .HasForeignKey(d => d.idPassenger);

        }
    }
}
