using AutoMapper;
using Online_Academy_Platform.Application.DTOs.LecturesFiles.Requests;
using Online_Academy_Platform.Application.DTOs.LecturesFiles.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class LectureFileService(
    ILectureFileRepository repository,
    ILectureRepository lectureRepository,
    IMapper mapper)
    : ILectureFileService
{
    public async Task<IEnumerable<LectureFileResponse>> GetByLectureIdAsync(int lectureId)
    {
        if (!await lectureRepository.ExistsAsync(lectureId))
            throw new NotFoundException(nameof(Lecture), lectureId);

        var files = await repository.GetByLectureIdAsync(lectureId);
        return mapper.Map<IEnumerable<LectureFileResponse>>(files);
    }

    public async Task<string> GetDownloadUrlAsync(int fileId)
    {
        var entity = await repository.GetByIdAsync(fileId);
        if (entity is null)
            throw new NotFoundException(nameof(LectureFile), fileId);

        return entity.FileUrl;
    }

    public async Task<LectureFileResponse> AddAsync(CreateLectureFileRequest request)
    {
        if (!await lectureRepository.ExistsAsync(request.LectureId))
            throw new NotFoundException(nameof(Lecture), request.LectureId);

        var entity = mapper.Map<LectureFile>(request);
        var created = await repository.AddAsync(entity);
        return mapper.Map<LectureFileResponse>(created);
    }

    public async Task<LectureFileResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(LectureFile), id);

        return mapper.Map<LectureFileResponse>(entity);
    }

    public async Task<IEnumerable<LectureFileResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<LectureFileResponse>>(entities);
    }

    public async Task<LectureFileResponse> UpdateAsync(int id, UpdateLectureFileRequest request)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(LectureFile), id);

        entity.FileUrl = request.FileUrl;
        await repository.UpdateAsync(entity);

        return mapper.Map<LectureFileResponse>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(LectureFile), id);

        await repository.DeleteAsync(id);
    }
}