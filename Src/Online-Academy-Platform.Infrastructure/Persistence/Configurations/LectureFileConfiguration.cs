using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Infrastructure.Persistence.Configurations;

public class LectureFileConfiguration : IEntityTypeConfiguration<LectureFile>
{
    public void Configure(EntityTypeBuilder<LectureFile> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.FileUrl).HasMaxLength(2000).IsRequired();

        builder.HasOne(f => f.Lecture)
            .WithMany(l => l.Files)
            .HasForeignKey(f => f.LectureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
