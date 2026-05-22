using Microsoft.Extensions.DependencyInjection;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Application.Services;

namespace Online_Academy_Platform.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ICourseInstructorService, CourseInstructorService>();
        services.AddScoped<ILectureService, LectureService>();
        services.AddScoped<ILectureFileService, LectureFileService>();
        services.AddScoped<IAssignmentService, AssignmentService>();
        services.AddScoped<IAssignmentSubmissionService, AssignmentSubmissionService>();
        services.AddScoped<IAttendanceService, AttendanceService>();
        services.AddScoped<IEnrollmentService, EnrollmentService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<ICouponService, CouponService>();
        services.AddScoped<ICertificateService, CertificateService>();
        services.AddScoped<INotificationService, NotificationService>();

        return services;
    }
}
