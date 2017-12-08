using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class busMap : EntityTypeConfiguration<bus>
    {
        public busMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.matricule)
                .IsRequired()
                .HasMaxLength(45);

            // Table & Column Mappings
            this.ToTable("bus", "didon_db");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.matricule).HasColumnName("matricule");
            this.Property(t => t.effectif).HasColumnName("effectif");
        }
    }
}
