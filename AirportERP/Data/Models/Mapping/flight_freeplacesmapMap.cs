using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class flight_freeplacesmapMap : EntityTypeConfiguration<flight_freeplacesmap>
    {
        public flight_freeplacesmapMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Flight_id, t.freePlacesMap_KEY });

            // Properties
            this.Property(t => t.Flight_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.freePlacesMap_KEY)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("flight_freeplacesmap", "didon_db");
            this.Property(t => t.Flight_id).HasColumnName("Flight_id");
            this.Property(t => t.freePlacesMap).HasColumnName("freePlacesMap");
            this.Property(t => t.freePlacesMap_KEY).HasColumnName("freePlacesMap_KEY");

            // Relationships
            this.HasRequired(t => t.flight)
                .WithMany(t => t.flight_freeplacesmap)
                .HasForeignKey(d => d.Flight_id);

        }
    }
}
