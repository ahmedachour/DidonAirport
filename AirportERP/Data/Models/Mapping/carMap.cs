using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class carMap : EntityTypeConfiguration<car>
    {
        public carMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.brand)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.registrationNumber)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("car", "didon_db");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.brand).HasColumnName("brand");
            this.Property(t => t.category).HasColumnName("category");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.registrationNumber).HasColumnName("registrationNumber");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.idCarRentalAgency).HasColumnName("idCarRentalAgency");

            // Relationships
            this.HasOptional(t => t.carrentalagency)
                .WithMany(t => t.cars)
                .HasForeignKey(d => d.idCarRentalAgency);

        }
    }
}
