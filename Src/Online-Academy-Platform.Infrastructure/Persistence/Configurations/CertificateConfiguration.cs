using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Infrastructure.Persistence.Configurations;

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.CertificateUrl).HasMaxLength(2000).IsRequired();

        builder.HasIndex(c => new { c.UserId, c.CourseId }).IsUnique();

        builder.HasOne(c => c.User)
            .WithMany(u => u.Certificates)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Course)
            .WithMany(course => course.Certificates)
            .HasForeignKey(c => c.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
