using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMS.api.Entities;

namespace TMS.api.Persistance.EntityConfigs
{
    public class CategoryConfig : BaseEntityConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CategoryName)
                .HasMaxLength(50);

            builder.Property(x => x.CategoryDescription)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

        }
    }
}
