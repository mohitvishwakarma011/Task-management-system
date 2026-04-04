using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMS.api.Entities;

namespace TMS.api.Persistance.EntityConfigs
{
    public class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : Audit
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
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
