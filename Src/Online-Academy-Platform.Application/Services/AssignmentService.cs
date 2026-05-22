using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Assignments.Requests;
using Online_Academy_Platform.Application.DTOs.Assignments.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class AssignmentService(
    IAssignmentRepository repository,
    ICourseRepository courseRepository,
    IMapper mapper)
    : IAssignmentService
{
    public async Task<IEnumerable<AssignmentResponse>> GetByCourseIdAsync(int courseId)
    {
        if (!await courseRepository.ExistsAsync(courseId))
            throw new NotFoundException(nameof(Course), courseId);

        var assignments = await repository.GetByCourseIdAsync(courseId);
        return mapper.Map<IEnumerable<AssignmentResponse>>(assignments);
    }

    public async Task<AssignmentResponse> AddAsync(CreateAssignmentRequest request)
    {
        if (!await courseRepository.ExistsAsync(request.CourseId))
            throw new NotFoundException(nameof(Course), request.CourseId);

        if (await repository.ExistsByCourseAndTitleAsync(request.CourseId, request.Title))
            throw new ValidationException(
                $"Assignment with title '{request.Title}' already exists in course {request.CourseId}.");

        var entity = mapper.Map<Assignment>(request);
        var created = await repository.AddAsync(entity);
        return mapper.Map<AssignmentResponse>(created);
    }

    public async Task<AssignmentResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Assignment), id);

        return mapper.Map<AssignmentResponse>(entity);
    }

    public async Task<IEnumerable<AssignmentResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<AssignmentResponse>>(entities);
    }

    public async Task<AssignmentResponse> UpdateAsync(int id, UpdateAssignmentRequest request)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Assignment), id);

        mapper.Map(request, entity);
        await repository.UpdateAsync(entity);

        return mapper.Map<AssignmentResponse>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(Assignment), id);

        await repository.DeleteAsync(id);
    }
}