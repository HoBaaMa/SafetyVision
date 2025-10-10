using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyVision.Core.Entities;

namespace SafetyVision.Infrastructure.Data.Configurations
{
    internal class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Username)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(w => w.Username)
                .IsUnique();

            builder.Property(w => w.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(w => w.Department)
                .WithMany(d => d.Workers)
                .HasForeignKey(w => w.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(w => w.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(w => w.Gender)
                .HasConversion<string>();

            builder.Property(w => w.PasswordHash)
                .HasMaxLength(int.MaxValue);
        }
    }
}
