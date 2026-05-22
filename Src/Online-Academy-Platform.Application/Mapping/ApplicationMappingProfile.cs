using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Assignments.Requests;
using Online_Academy_Platform.Application.DTOs.Assignments.Responses;
using Online_Academy_Platform.Application.DTOs.Attendances.Requests;
using Online_Academy_Platform.Application.DTOs.Attendances.Responses;
using Online_Academy_Platform.Application.DTOs.Certificates.Requests;
using Online_Academy_Platform.Application.DTOs.Certificates.Responses;
using Online_Academy_Platform.Application.DTOs.Coupons.Requests;
using Online_Academy_Platform.Application.DTOs.Coupons.Responses;
using Online_Academy_Platform.Application.DTOs.CourseInstructors.Requests;
using Online_Academy_Platform.Application.DTOs.CourseInstructors.Responses;
using Online_Academy_Platform.Application.DTOs.Courses.Requests;
using Online_Academy_Platform.Application.DTOs.Courses.Responses;
using Online_Academy_Platform.Application.DTOs.Enrollments.Requests;
using Online_Academy_Platform.Application.DTOs.Enrollments.Responses;
using Online_Academy_Platform.Application.DTOs.Lectures.Requests;
using Online_Academy_Platform.Application.DTOs.Lectures.Responses;
using Online_Academy_Platform.Application.DTOs.LecturesFiles.Requests;
using Online_Academy_Platform.Application.DTOs.LecturesFiles.Responses;
using Online_Academy_Platform.Application.DTOs.Notifications.Requests;
using Online_Academy_Platform.Application.DTOs.Notifications.Responses;
using Online_Academy_Platform.Application.DTOs.Payments.Requests;
using Online_Academy_Platform.Application.DTOs.Payments.Responses;
using Online_Academy_Platform.Application.DTOs.Users.Requests;
using Online_Academy_Platform.Application.DTOs.Users.Responses;
using Online_Academy_Platform.Domain.Entities;

namespace Online_Academy_Platform.Application.Mapping;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        // ==================== User ====================
        CreateMap<RegisterUserRequest, User>();
        CreateMap<UpdateUserRequest, User>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<User, UserResponse>();

        // ==================== Course ====================
        CreateMap<CreateCourseRequest, Course>();
        CreateMap<UpdateCourseRequest, Course>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Course, CourseResponse>();

        // ==================== Lecture ====================
        CreateMap<CreateLectureRequest, Lecture>();
        CreateMap<UpdateLectureRequest, Lecture>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Lecture, LectureResponse>();

        // ==================== LectureFile ====================
        CreateMap<CreateLectureFileRequest, LectureFile>();
        CreateMap<LectureFile, LectureFileResponse>();

        // ==================== Assignment ====================
        CreateMap<CreateAssignmentRequest, Assignment>();
        CreateMap<UpdateAssignmentRequest, Assignment>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Assignment, AssignmentResponse>();

        // ==================== AssignmentSubmission ====================
        CreateMap<SubmitAssignmentRequest, AssignmentSubmission>();
        CreateMap<AssignmentSubmission, AssignmentSubmissionResponse>();

        // ==================== Coupon ====================
        CreateMap<CreateCouponRequest, Coupon>();
        CreateMap<UpdateCouponRequest, Coupon>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Coupon, CouponResponse>();

        // ==================== Payment ====================
        CreateMap<CreatePaymentRequest, Payment>();
        CreateMap<UpdatePaymentStatusRequest, Payment>();
        CreateMap<Payment, PaymentResponse>();

        // ==================== CourseInstructor ====================
        CreateMap<AssignInstructorRequest, CourseInstructor>();
        CreateMap<CourseInstructor, CourseInstructorResponse>();

        // ==================== Enrollment ====================
        CreateMap<EnrollRequest, Enrollment>();
        CreateMap<Enrollment, EnrollmentResponse>();

        // ==================== Certificate ====================
        CreateMap<IssueCertificateRequest, Certificate>();
        CreateMap<Certificate, CertificateResponse>();

        // ==================== Attendance ====================
        CreateMap<RecordAttendanceRequest, Attendance>();
        CreateMap<Attendance, AttendanceResponse>();

        // ==================== Notification ====================
        CreateMap<SendNotificationRequest, Notification>();
        CreateMap<Notification, NotificationResponse>();
    }
}