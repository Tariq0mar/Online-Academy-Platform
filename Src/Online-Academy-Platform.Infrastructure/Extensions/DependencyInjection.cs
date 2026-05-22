using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories;

namespace Online_Academy_Platform.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseInstructorRepository, CourseInstructorRepository>();
        services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        services.AddScoped<ILectureRepository, LectureRepository>();
        services.AddScoped<ILectureFileRepository, LectureFileRepository>();
        services.AddScoped<IAssignmentRepository, AssignmentRepository>();
        services.AddScoped<IAssignmentSubmissionRepository, AssignmentSubmissionRepository>();
        services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        services.AddScoped<ICouponRepository, CouponRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();

        return services;
    }
}
