using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Assignments.Requests;
using Online_Academy_Platform.Application.DTOs.Assignments.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class AssignmentSubmissionService(
    IAssignmentSubmissionRepository repository,
    IAssignmentRepository assignmentRepository,
    IUserRepository userRepository,
    IMapper mapper)
    : IAssignmentSubmissionService
{
    public async Task<AssignmentSubmissionResponse> SubmitAsync(SubmitAssignmentRequest request)
    {
        if (!await assignmentRepository.ExistsAsync(request.AssignmentId))
            throw new NotFoundException(nameof(Assignment), request.AssignmentId);

        if (!await userRepository.ExistsAsync(request.UserId))
            throw new NotFoundException(nameof(User), request.UserId);

        if (await repository.ExistsByAssignmentAndUserAsync(request.AssignmentId, request.UserId))
            throw new ValidationException(
                $"Submission already exists for user {request.UserId} in assignment {request.AssignmentId}.");

        var entity = mapper.Map<AssignmentSubmission>(request);
        entity.SubmissionDate = DateTime.UtcNow;
        entity.Status = SubmissionStatus.Pending;

        var created = await repository.AddAsync(entity);
        return mapper.Map<AssignmentSubmissionResponse>(created);
    }

    public async Task<AssignmentSubmissionResponse> ResubmitAsync(int id, SubmitAssignmentRequest request)
    {
        var existing = await repository.GetByIdAsync(id);
        if (existing is null)
            throw new NotFoundException(nameof(AssignmentSubmission), id);

        existing.SubmissionFile = request.SubmissionFile;
        existing.SubmissionDate = DateTime.UtcNow;
        existing.Status = SubmissionStatus.Pending;
        existing.Grade = null;
        existing.Feedback = null;

        await repository.UpdateAsync(existing);
        return mapper.Map<AssignmentSubmissionResponse>(existing);
    }

    public async Task GradeAsync(GradeAssignmentRequest request)
    {
        var entity = await repository.GetByIdAsync(request.SubmissionId);
        if (entity is null)
            throw new NotFoundException(nameof(AssignmentSubmission), request.SubmissionId);

        if (request.Grade < 0)
            throw new ValidationException("Grade cannot be negative.");

        var status = request.Grade >= 0 ? SubmissionStatus.Graded : SubmissionStatus.Rejected;

        await repository.UpdateGradeAsync(request.SubmissionId, request.Grade, request.Feedback, status);
    }

    public async Task<AssignmentSubmissionResponse> GetByAssignmentAndUserAsync(int assignmentId, int userId)
    {
        var entity = await repository.GetByAssignmentAndUserAsync(assignmentId, userId);
        if (entity is null)
            throw new NotFoundException(
                $"Submission for assignment {assignmentId} and user {userId} was not found.");

        return mapper.Map<AssignmentSubmissionResponse>(entity);
    }

    public async Task<IEnumerable<AssignmentSubmissionResponse>> GetByAssignmentIdAsync(int assignmentId)
    {
        if (!await assignmentRepository.ExistsAsync(assignmentId))
            throw new NotFoundException(nameof(Assignment), assignmentId);

        var submissions = await repository.GetByAssignmentIdAsync(assignmentId);
        return mapper.Map<IEnumerable<AssignmentSubmissionResponse>>(submissions);
    }

    public async Task<IEnumerable<AssignmentSubmissionResponse>> GetByUserIdAsync(int userId)
    {
        if (!await userRepository.ExistsAsync(userId))
            throw new NotFoundException(nameof(User), userId);

        var submissions = await repository.GetByUserIdAsync(userId);
        return mapper.Map<IEnumerable<AssignmentSubmissionResponse>>(submissions);
    }
    public async Task<AssignmentSubmissionResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(AssignmentSubmission), id);

        return mapper.Map<AssignmentSubmissionResponse>(entity);
    }

    public async Task<IEnumerable<AssignmentSubmissionResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<AssignmentSubmissionResponse>>(entities);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(AssignmentSubmission), id);

        await repository.DeleteAsync(id);
    }
}