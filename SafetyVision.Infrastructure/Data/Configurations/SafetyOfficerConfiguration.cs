using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyVision.Core.Entities;

namespace SafetyVision.Infrastructure.Data.Configurations
{
    internal class SafetyOfficerConfiguration : IEntityTypeConfiguration<SafetyOfficer>
    {
        public void Configure(EntityTypeBuilder<SafetyOfficer> builder)
        {
            builder.HasKey(so => so.Id);

            builder.Property(so => so.Username)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(so => so.Username)
                .IsUnique();

            builder.Property(so => so.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(so => so.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(so => so.Gender)
                .HasConversion<string>();

            builder.Property(so => so.PasswordHash)
                .HasMaxLength(int.MaxValue);
        }
    }
}
