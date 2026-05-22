using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<CourseInstructor> CourseInstructors => Set<CourseInstructor>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Lecture> Lectures => Set<Lecture>();
    public DbSet<LectureFile> LectureFiles => Set<LectureFile>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<AssignmentSubmission> AssignmentSubmissions => Set<AssignmentSubmission>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Certificate> Certificates => Set<Certificate>();
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
