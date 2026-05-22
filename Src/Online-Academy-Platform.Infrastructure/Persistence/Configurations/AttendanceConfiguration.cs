using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Infrastructure.Persistence.Configurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.HasKey(a => a.Id);

        builder.HasIndex(a => new { a.LectureId, a.UserId }).IsUnique();

        builder.HasOne(a => a.Lecture)
            .WithMany(l => l.Attendances)
            .HasForeignKey(a => a.LectureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.User)
            .WithMany(u => u.Attendances)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
