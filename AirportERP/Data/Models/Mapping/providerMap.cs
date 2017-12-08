using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class providerMap : EntityTypeConfiguration<provider>
    {
        public providerMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.companyName)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.managerName)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("provider", "didon_db");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.companyName).HasColumnName("companyName");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.managerName).HasColumnName("managerName");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.phoneNumber).HasColumnName("phoneNumber");
        }
    }
}
