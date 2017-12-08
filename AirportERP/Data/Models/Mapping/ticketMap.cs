using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class ticketMap : EntityTypeConfiguration<ticket>
    {
        public ticketMap()
        {
            // Primary Key
            this.HasKey(t => new { t.idFlight, t.idPassenger });

            // Properties
            this.Property(t => t.idFlight)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idPassenger)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ticket", "didon_db");
            this.Property(t => t.idFlight).HasColumnName("idFlight");
            this.Property(t => t.idPassenger).HasColumnName("idPassenger");
            this.Property(t => t.flightCategory).HasColumnName("flightCategory");
            this.Property(t => t.price).HasColumnName("price");

            // Relationships
            this.HasRequired(t => t.flight)
                .WithMany(t => t.tickets)
                .HasForeignKey(d => d.idFlight);
            this.HasRequired(t => t.user)
                .WithMany(t => t.tickets)
                .HasForeignKey(d => d.idPassenger);

        }
    }
}
