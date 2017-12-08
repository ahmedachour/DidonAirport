using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class flightMap : EntityTypeConfiguration<flight>
    {
        public flightMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.company)
                .HasMaxLength(255);

            this.Property(t => t.destination)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("flight", "didon_db");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.company).HasColumnName("company");
            this.Property(t => t.date_arrival).HasColumnName("date_arrival");
            this.Property(t => t.date_departure).HasColumnName("date_departure");
            this.Property(t => t.destination).HasColumnName("destination");
            this.Property(t => t.idStaff).HasColumnName("idStaff");
            this.Property(t => t.idPlane).HasColumnName("idPlane");
            this.Property(t => t.idBus).HasColumnName("idBus");

            // Relationships
            this.HasOptional(t => t.bus)
                .WithMany(t => t.flights)
                .HasForeignKey(d => d.idBus);
            this.HasOptional(t => t.plane)
                .WithMany(t => t.flights)
                .HasForeignKey(d => d.idPlane);
            this.HasOptional(t => t.staff)
                .WithMany(t => t.flights)
                .HasForeignKey(d => d.idStaff);

        }
    }
}
