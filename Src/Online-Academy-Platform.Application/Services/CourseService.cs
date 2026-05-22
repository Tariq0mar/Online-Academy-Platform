using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Courses.Requests;
using Online_Academy_Platform.Application.DTOs.Courses.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class CourseService(
    ICourseRepository repository,
    ICourseInstructorRepository courseInstructorRepository,
    IMapper mapper)
    : ICourseService
{
    public async Task<IEnumerable<CourseResponse>> GetByInstructorIdAsync(int instructorId)
    {
        var assignments = await courseInstructorRepository.GetByInstructorIdAsync(instructorId);
        var courseIds = assignments.Select(a => a.CourseId).Distinct();
        var courses = new List<Course>();
        foreach (var id in courseIds)
        {
            var course = await repository.GetByIdAsync(id);
            if (course is not null)
                courses.Add(course);
        }
        return mapper.Map<IEnumerable<CourseResponse>>(courses);
    }

    public async Task<CourseResponse> AddAsync(CreateCourseRequest request)
    {
        var entity = mapper.Map<Course>(request);
        entity.CreatedAt = DateTime.UtcNow;
        var created = await repository.AddAsync(entity);
        return mapper.Map<CourseResponse>(created);
    }

    public async Task<CourseResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Course), id);

        return mapper.Map<CourseResponse>(entity);
    }

    public async Task<IEnumerable<CourseResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<CourseResponse>>(entities);
    }

    public async Task<CourseResponse> UpdateAsync(int id, UpdateCourseRequest request)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Course), id);

        mapper.Map(request, entity);
        await repository.UpdateAsync(entity);

        return mapper.Map<CourseResponse>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(Course), id);

        await repository.DeleteAsync(id);
    }
}