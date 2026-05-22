using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Infrastructure.Persistence.Configurations;

public class LectureConfiguration : IEntityTypeConfiguration<Lecture>
{
    public void Configure(EntityTypeBuilder<Lecture> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Title).HasMaxLength(300).IsRequired();
        builder.Property(l => l.Description).HasMaxLength(4000);

        builder.HasIndex(l => new { l.CourseId, l.Title }).IsUnique();

        builder.HasOne(l => l.Course)
            .WithMany(c => c.Lectures)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
