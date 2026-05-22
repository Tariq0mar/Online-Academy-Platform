using AutoMapper;
using Online_Academy_Platform.Application.DTOs.CourseInstructors.Requests;
using Online_Academy_Platform.Application.DTOs.CourseInstructors.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class CourseInstructorService(
    ICourseInstructorRepository repository,
    ICourseRepository courseRepository,
    IUserRepository userRepository,
    IMapper mapper)
    : ICourseInstructorService
{
    public async Task<IEnumerable<CourseInstructorResponse>> GetByCourseIdAsync(int courseId)
    {
        if (!await courseRepository.ExistsAsync(courseId))
            throw new NotFoundException(nameof(Course), courseId);

        var instructors = await repository.GetByCourseIdAsync(courseId);
        return mapper.Map<IEnumerable<CourseInstructorResponse>>(instructors);
    }

    public async Task<IEnumerable<CourseInstructorResponse>> GetByInstructorIdAsync(int instructorId)
    {
        if (!await userRepository.ExistsAsync(instructorId))
            throw new NotFoundException(nameof(User), instructorId);

        var assignments = await repository.GetByInstructorIdAsync(instructorId);
        return mapper.Map<IEnumerable<CourseInstructorResponse>>(assignments);
    }

    public async Task<CourseInstructorResponse> AssignAsync(AssignInstructorRequest request)
    {
        if (!await courseRepository.ExistsAsync(request.CourseId))
            throw new NotFoundException(nameof(Course), request.CourseId);

        if (!await userRepository.ExistsAsync(request.InstructorId))
            throw new NotFoundException(nameof(User), request.InstructorId);

        if (await repository.ExistsByCourseAndInstructorAsync(request.CourseId, request.InstructorId))
            throw new ValidationException(
                $"Instructor {request.InstructorId} is already assigned to course {request.CourseId}.");

        if (request.IsPrimary && await repository.HasPrimaryInstructorAsync(request.CourseId))
            await repository.ClearPrimaryForCourseAsync(request.CourseId);

        var entity = mapper.Map<CourseInstructor>(request);
        entity.AssignedAt = DateTime.UtcNow;

        var created = await repository.AddAsync(entity);
        return mapper.Map<CourseInstructorResponse>(created);
    }

    public async Task RemoveAsync(RemoveInstructorRequest request)
    {
        if (!await repository.ExistsByCourseAndInstructorAsync(request.CourseId, request.InstructorId))
            throw new NotFoundException(
                $"Assignment for course {request.CourseId} and instructor {request.InstructorId} was not found.");

        await repository.DeleteByCourseAndInstructorAsync(request.CourseId, request.InstructorId);
    }

    public async Task<CourseInstructorResponse> SetPrimaryInstructorAsync(AssignInstructorRequest request)
    {
        var assignment = await repository.GetByCourseAndInstructorAsync(request.CourseId, request.InstructorId);
        if (assignment is null)
            throw new NotFoundException(
                $"Assignment for course {request.CourseId} and instructor {request.InstructorId} was not found.");

        await repository.ClearPrimaryForCourseAsync(request.CourseId);

        assignment.IsPrimary = true;
        await repository.UpdateAsync(assignment);

        return mapper.Map<CourseInstructorResponse>(assignment);
    }

    public async Task<CourseInstructorResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(CourseInstructor), id);

        return mapper.Map<CourseInstructorResponse>(entity);
    }

    public async Task<IEnumerable<CourseInstructorResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<CourseInstructorResponse>>(entities);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(CourseInstructor), id);

        await repository.DeleteAsync(id);
    }
}