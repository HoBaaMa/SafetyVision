using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyVision.Core.Entities;

namespace SafetyVision.Infrastructure.Data.Configurations
{
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.HasOne(n => n.SafetyOfficer)
                .WithMany(so => so.Notifications)
                .HasForeignKey(n => n.SenderOfficerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(n => n.Worker)
                .WithMany(so => so.Notifications)
                .HasForeignKey(n => n.ReciverWorkerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(n => n.Message)
                .HasMaxLength(500);

            builder.Property(n => n.Type)
                .HasMaxLength(50)
                .HasConversion<string>();

            builder.Property(n => n.Status)
                .HasMaxLength(20)
                .HasConversion<string>();
        }
    }
}
