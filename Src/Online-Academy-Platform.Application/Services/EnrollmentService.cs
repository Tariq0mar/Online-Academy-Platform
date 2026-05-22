using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Enrollments.Requests;
using Online_Academy_Platform.Application.DTOs.Enrollments.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class EnrollmentService(
    IEnrollmentRepository repository,
    IUserRepository userRepository,
    ICourseRepository courseRepository,
    IMapper mapper)
    : IEnrollmentService
{
    public async Task<EnrollmentResponse> EnrollAsync(EnrollRequest request)
    {
        if (!await userRepository.ExistsAsync(request.UserId))
            throw new NotFoundException(nameof(User), request.UserId);

        if (!await courseRepository.ExistsAsync(request.CourseId))
            throw new NotFoundException(nameof(Course), request.CourseId);

        if (await repository.ExistsByUserAndCourseAsync(request.UserId, request.CourseId))
            throw new ValidationException(
                $"User {request.UserId} is already enrolled in course {request.CourseId}.");

        var entity = mapper.Map<Enrollment>(request);
        entity.Status = EnrollmentStatus.PendingPayment;
        entity.EnrolledAt = DateTime.UtcNow;

        var created = await repository.AddAsync(entity);
        return mapper.Map<EnrollmentResponse>(created);
    }

    public async Task<EnrollmentResponse> GetByUserAndCourseAsync(int userId, int courseId)
    {
        var entity = await repository.GetByUserAndCourseAsync(userId, courseId);
        if (entity is null)
            throw new NotFoundException(
                $"Enrollment for user {userId} in course {courseId} was not found.");

        return mapper.Map<EnrollmentResponse>(entity);
    }

    public async Task<bool> IsEnrolledAsync(int userId, int courseId) =>
        await repository.ExistsByUserAndCourseAsync(userId, courseId);

    public async Task CancelAsync(int enrollmentId)
    {
        var entity = await repository.GetByIdAsync(enrollmentId);
        if (entity is null)
            throw new NotFoundException(nameof(Enrollment), enrollmentId);

        entity.Status = EnrollmentStatus.Cancelled;
        await repository.UpdateAsync(entity);
    }

    public async Task<IEnumerable<EnrollmentResponse>> GetByUserIdAsync(int userId)
    {
        if (!await userRepository.ExistsAsync(userId))
            throw new NotFoundException(nameof(User), userId);

        var enrollments = await repository.GetByUserIdAsync(userId);
        return mapper.Map<IEnumerable<EnrollmentResponse>>(enrollments);
    }

    public async Task<IEnumerable<EnrollmentResponse>> GetByCourseIdAsync(int courseId)
    {
        if (!await courseRepository.ExistsAsync(courseId))
            throw new NotFoundException(nameof(Course), courseId);

        var enrollments = await repository.GetByCourseIdAsync(courseId);
        return mapper.Map<IEnumerable<EnrollmentResponse>>(enrollments);
    }

    public async Task<EnrollmentResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Enrollment), id);

        return mapper.Map<EnrollmentResponse>(entity);
    }

    public async Task<IEnumerable<EnrollmentResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<EnrollmentResponse>>(entities);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(Enrollment), id);

        await repository.DeleteAsync(id);
    }
}