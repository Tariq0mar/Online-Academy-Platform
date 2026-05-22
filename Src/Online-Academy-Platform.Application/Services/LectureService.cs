using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Lectures.Requests;
using Online_Academy_Platform.Application.DTOs.Lectures.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class LectureService(
    ILectureRepository repository,
    ICourseRepository courseRepository,
    IMapper mapper)
    : ILectureService
{
    public async Task<IEnumerable<LectureResponse>> GetByCourseIdAsync(int courseId)
    {
        if (!await courseRepository.ExistsAsync(courseId))
            throw new NotFoundException(nameof(Course), courseId);

        var lectures = await repository.GetByCourseIdAsync(courseId);
        return mapper.Map<IEnumerable<LectureResponse>>(lectures);
    }

    public async Task ReorderAsync(int courseId, ReorderLecturesRequest request)
    {
        var lectures = (await repository.GetByCourseIdAsync(courseId)).ToList();
        if (lectures.Count == 0)
            throw new NotFoundException(nameof(Course), courseId);

        var existingIds = new HashSet<int>(lectures.Select(l => l.Id));
        foreach (var item in request.Items)
        {
            if (!existingIds.Contains(item.LectureId))
                throw new NotFoundException(nameof(Lecture), item.LectureId);

            var lecture = lectures.First(l => l.Id == item.LectureId);
            lecture.LectureDate = lecture.LectureDate.AddHours(item.NewOrder);
            await repository.UpdateAsync(lecture);
        }
    }

    public async Task<LectureResponse> AddAsync(CreateLectureRequest request)
    {
        if (!await courseRepository.ExistsAsync(request.CourseId))
            throw new NotFoundException(nameof(Course), request.CourseId);

        var entity = mapper.Map<Lecture>(request);
        var created = await repository.AddAsync(entity);
        return mapper.Map<LectureResponse>(created);
    }

    public async Task<LectureResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Lecture), id);

        return mapper.Map<LectureResponse>(entity);
    }

    public async Task<IEnumerable<LectureResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<LectureResponse>>(entities);
    }

    public async Task<LectureResponse> UpdateAsync(int id, UpdateLectureRequest request)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Lecture), id);

        mapper.Map(request, entity);
        await repository.UpdateAsync(entity);

        return mapper.Map<LectureResponse>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(Lecture), id);

        await repository.DeleteAsync(id);
    }
}