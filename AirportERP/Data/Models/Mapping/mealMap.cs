using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class mealMap : EntityTypeConfiguration<meal>
    {
        public mealMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("meal", "didon_db");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.category).HasColumnName("category");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.quantity).HasColumnName("quantity");
            this.Property(t => t.idPassenger).HasColumnName("idPassenger");
            this.Property(t => t.idProvider).HasColumnName("idProvider");
            this.Property(t => t.idFlight).HasColumnName("idFlight");

            // Relationships
            this.HasOptional(t => t.flight)
                .WithMany(t => t.meals)
                .HasForeignKey(d => d.idFlight);
            this.HasOptional(t => t.provider)
                .WithMany(t => t.meals)
                .HasForeignKey(d => d.idProvider);
            this.HasOptional(t => t.user)
                .WithMany(t => t.meals)
                .HasForeignKey(d => d.idPassenger);

        }
    }
}
