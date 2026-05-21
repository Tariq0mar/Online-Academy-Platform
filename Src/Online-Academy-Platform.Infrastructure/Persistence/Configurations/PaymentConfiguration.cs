using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.TransactionId).HasMaxLength(200).IsRequired();
        builder.Property(p => p.OriginalAmount).HasPrecision(18, 2);
        builder.Property(p => p.DiscountAmount).HasPrecision(18, 2);
        builder.Property(p => p.FinalAmount).HasPrecision(18, 2);

        builder.HasIndex(p => p.TransactionId).IsUnique();

        builder.HasOne(p => p.User)
            .WithMany(u => u.Payments)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Course)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Enrollment)
            .WithMany(e => e.Payments)
            .HasForeignKey(p => p.EnrollmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(p => p.Coupon)
            .WithMany(c => c.Payments)
            .HasForeignKey(p => p.CouponId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
