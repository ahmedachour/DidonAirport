using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class carrentalagencyMap : EntityTypeConfiguration<carrentalagency>
    {
        public carrentalagencyMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.company_name)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.manager_name)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("carrentalagency", "didon_db");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.company_name).HasColumnName("company_name");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.manager_name).HasColumnName("manager_name");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.phone_number).HasColumnName("phone_number");
        }
    }
}
