using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyVision.Core.Entities;

namespace SafetyVision.Infrastructure.Data.Configurations
{
    internal class ViolationConfiguration : IEntityTypeConfiguration<Violation>
    {
        public void Configure(EntityTypeBuilder<Violation> builder)
        {
            builder.HasKey(v => v.Id);

            builder.HasOne(v => v.Worker)
                .WithMany(w => w.Violations)
                .HasForeignKey(v => v.WorkerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(v => v.Description)
                .HasMaxLength(500);

            builder.Property(v => v.Type)
                .HasMaxLength(100)
                .HasConversion<string>();

            builder.Property(v => v.Severity)
                .HasMaxLength(50)
                .HasConversion<string>();

            builder.Property(v => v.Status)
                .HasMaxLength(50)
                .HasConversion<string>();
        }
    }
}
