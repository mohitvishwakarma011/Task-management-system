using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMS.api.Entities;

namespace TMS.api.Persistance.EntityConfigs
{
    public class AuditConfig:IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GetUtcDate()")
                .HasColumnType("datetime2");

            builder.Property(x => x.UpdatedAt)
                .IsRequired(false)
                .HasColumnType("datetime2");

            builder.Property(x => x.CreateById)
                .IsRequired();

            builder.Property(x => x.UpdateById)
                .IsRequired();
        }
    }
}
