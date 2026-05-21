using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Infrastructure.Persistence.Configurations;

public class CourseInstructorConfiguration : IEntityTypeConfiguration<CourseInstructor>
{
    public void Configure(EntityTypeBuilder<CourseInstructor> builder)
    {
        builder.HasKey(ci => ci.Id);

        builder.HasIndex(ci => new { ci.CourseId, ci.InstructorId }).IsUnique();

        builder.HasOne(ci => ci.Course)
            .WithMany(c => c.CourseInstructors)
            .HasForeignKey(ci => ci.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ci => ci.Instructor)
            .WithMany(u => u.CourseInstructorAssignments)
            .HasForeignKey(ci => ci.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
