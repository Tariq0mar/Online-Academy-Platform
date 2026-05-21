using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Infrastructure.Persistence.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title).HasMaxLength(300).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(4000).IsRequired();
        builder.Property(c => c.Price).HasPrecision(18, 2);
    }
}
