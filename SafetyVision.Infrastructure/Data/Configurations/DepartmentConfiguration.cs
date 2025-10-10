using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyVision.Core.Entities;

namespace SafetyVision.Infrastructure.Data.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .HasMaxLength(100);

            builder.Property(d => d.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
