using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class flight_pricemapMap : EntityTypeConfiguration<flight_pricemap>
    {
        public flight_pricemapMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Flight_id, t.priceMap_KEY });

            // Properties
            this.Property(t => t.Flight_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.priceMap_KEY)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("flight_pricemap", "didon_db");
            this.Property(t => t.Flight_id).HasColumnName("Flight_id");
            this.Property(t => t.priceMap).HasColumnName("priceMap");
            this.Property(t => t.priceMap_KEY).HasColumnName("priceMap_KEY");

            // Relationships
            this.HasRequired(t => t.flight)
                .WithMany(t => t.flight_pricemap)
                .HasForeignKey(d => d.Flight_id);

        }
    }
}
