using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMS.api.Entities;

namespace TMS.api.Persistance.EntityConfigs
{
    public class TaskItemConfig : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.ToTable("Task");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.DueDate)
                .IsRequired().HasColumnType("datetime2");

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GetUtcDate()");

            builder.Property(x => x.UpdatedAt)
                .IsRequired(false)
                .ValueGeneratedOnUpdate()
                .HasColumnType("datetime2");

            builder.Property(x => x.CreateById)
                .IsRequired();

            builder.Property(x => x.UpdateById)
                .IsRequired();

            builder.Property(x => x.Priority)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(x => x.AssignedToUserId)
                .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.IsDeleted)
                .IsRequired();

            //RelationShips
            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CtgryId)
                .OnDelete(DeleteBehavior.NoAction); //Will use soft delete
        }
    }
}