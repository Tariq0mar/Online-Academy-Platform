using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Certificates.Requests;
using Online_Academy_Platform.Application.DTOs.Certificates.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class CertificateService(
    ICertificateRepository repository,
    IUserRepository userRepository,
    ICourseRepository courseRepository,
    IMapper mapper)
    : ICertificateService
{
    public async Task<CertificateResponse> IssueAsync(IssueCertificateRequest request)
    {
        if (!await userRepository.ExistsAsync(request.UserId))
            throw new NotFoundException(nameof(User), request.UserId);

        if (!await courseRepository.ExistsAsync(request.CourseId))
            throw new NotFoundException(nameof(Course), request.CourseId);

        if (await repository.ExistsByUserAndCourseAsync(request.UserId, request.CourseId))
            throw new ValidationException(
                $"Certificate already exists for user {request.UserId} in course {request.CourseId}.");

        var entity = mapper.Map<Certificate>(request);
        entity.IssueDate = DateTime.UtcNow;

        var created = await repository.AddAsync(entity);
        return mapper.Map<CertificateResponse>(created);
    }

    public async Task<CertificateResponse> GetByUserAndCourseAsync(int userId, int courseId)
    {
        var entity = await repository.GetByUserAndCourseAsync(userId, courseId);
        if (entity is null)
            throw new NotFoundException(
                $"Certificate for user {userId} and course {courseId} was not found.");

        return mapper.Map<CertificateResponse>(entity);
    }

    public async Task<bool> HasCertificateAsync(int userId, int courseId) =>
        await repository.ExistsByUserAndCourseAsync(userId, courseId);

    public async Task<IEnumerable<CertificateResponse>> GetByUserIdAsync(int userId)
    {
        if (!await userRepository.ExistsAsync(userId))
            throw new NotFoundException(nameof(User), userId);

        var certificates = await repository.GetByUserIdAsync(userId);
        return mapper.Map<IEnumerable<CertificateResponse>>(certificates);
    }

    public async Task<bool> VerifyAsync(string certificateUrl)
    {
        var certificates = await repository.GetAllAsync();
        return certificates.Any(c => c.CertificateUrl == certificateUrl);
    }

    public async Task RevokeAsync(int certificateId)
    {
        var entity = await repository.GetByIdAsync(certificateId);
        if (entity is null)
            throw new NotFoundException(nameof(Certificate), certificateId);

        await repository.DeleteAsync(certificateId);
    }

    public async Task<CertificateResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Certificate), id);

        return mapper.Map<CertificateResponse>(entity);
    }

    public async Task<IEnumerable<CertificateResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<CertificateResponse>>(entities);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(Certificate), id);

        await repository.DeleteAsync(id);
    }
}