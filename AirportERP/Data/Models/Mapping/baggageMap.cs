using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class baggageMap : EntityTypeConfiguration<baggage>
    {
        public baggageMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("baggage", "didon_db");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.weight).HasColumnName("weight");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.idFlight).HasColumnName("idFlight");

            // Relationships
            this.HasOptional(t => t.flight)
                .WithMany(t => t.baggages)
                .HasForeignKey(d => d.idFlight);
            this.HasOptional(t => t.user)
                .WithMany(t => t.baggages)
                .HasForeignKey(d => d.idUser);

        }
    }
}
