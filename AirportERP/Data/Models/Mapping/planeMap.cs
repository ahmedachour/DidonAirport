using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class planeMap : EntityTypeConfiguration<plane>
    {
        public planeMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.type)
                .IsRequired()
                .HasMaxLength(45);

            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("plane", "didon_db");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.effectif).HasColumnName("effectif");
            this.Property(t => t.idRunway).HasColumnName("idRunway");

            // Relationships
            this.HasOptional(t => t.runway)
                .WithMany(t => t.planes)
                .HasForeignKey(d => d.idRunway);

        }
    }
}
