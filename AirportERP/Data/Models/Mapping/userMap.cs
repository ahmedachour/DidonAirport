using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.function)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.first_name)
                .HasMaxLength(255);

            this.Property(t => t.last_name)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.sexe)
                .HasMaxLength(255);

            this.Property(t => t.department)
                .HasMaxLength(255);

            this.Property(t => t.position)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("user", "didon_db");
            this.Property(t => t.function).HasColumnName("function");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.birth_date).HasColumnName("birth_date");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.first_name).HasColumnName("first_name");
            this.Property(t => t.last_name).HasColumnName("last_name");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.phone_number).HasColumnName("phone_number");
            this.Property(t => t.sexe).HasColumnName("sexe");
            this.Property(t => t.department).HasColumnName("department");
            this.Property(t => t.position).HasColumnName("position");
            this.Property(t => t.idStaff).HasColumnName("idStaff");

            // Relationships
            this.HasOptional(t => t.staff)
                .WithMany(t => t.users)
                .HasForeignKey(d => d.idStaff);

        }
    }
}
