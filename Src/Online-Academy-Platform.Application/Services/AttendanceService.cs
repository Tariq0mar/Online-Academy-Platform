using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Attendances.Requests;
using Online_Academy_Platform.Application.DTOs.Attendances.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class AttendanceService(
    IAttendanceRepository repository,
    ILectureRepository lectureRepository,
    IUserRepository userRepository,
    IMapper mapper)
    : IAttendanceService
{
    public async Task<AttendanceResponse> RecordAsync(RecordAttendanceRequest request)
    {
        if (!await lectureRepository.ExistsAsync(request.LectureId))
            throw new NotFoundException(nameof(Lecture), request.LectureId);

        if (!await userRepository.ExistsAsync(request.UserId))
            throw new NotFoundException(nameof(User), request.UserId);

        if (await repository.ExistsByLectureAndUserAsync(request.LectureId, request.UserId))
            throw new ValidationException(
                $"Attendance already recorded for user {request.UserId} in lecture {request.LectureId}.");

        var entity = mapper.Map<Attendance>(request);
        var created = await repository.AddAsync(entity);
        return mapper.Map<AttendanceResponse>(created);
    }

    public async Task<IEnumerable<AttendanceResponse>> BulkRecordAsync(IEnumerable<RecordAttendanceRequest> records)
    {
        var results = new List<AttendanceResponse>();

        foreach (var request in records)
        {
            var response = await RecordAsync(request);
            results.Add(response);
        }

        return results;
    }

    public async Task<AttendanceResponse> GetByLectureAndUserAsync(int lectureId, int userId)
    {
        var entity = await repository.GetByLectureAndUserAsync(lectureId, userId);
        if (entity is null)
            throw new NotFoundException(
                $"Attendance for user {userId} in lecture {lectureId} was not found.");

        return mapper.Map<AttendanceResponse>(entity);
    }

    public async Task<IEnumerable<AttendanceResponse>> GetByLectureIdAsync(int lectureId)
    {
        if (!await lectureRepository.ExistsAsync(lectureId))
            throw new NotFoundException(nameof(Lecture), lectureId);

        var attendances = await repository.GetByLectureIdAsync(lectureId);
        return mapper.Map<IEnumerable<AttendanceResponse>>(attendances);
    }

    public async Task<IEnumerable<AttendanceResponse>> GetByUserIdAsync(int userId)
    {
        if (!await userRepository.ExistsAsync(userId))
            throw new NotFoundException(nameof(User), userId);

        var attendances = await repository.GetByUserIdAsync(userId);
        return mapper.Map<IEnumerable<AttendanceResponse>>(attendances);
    }
    
    public async Task<AttendanceResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Attendance), id);

        return mapper.Map<AttendanceResponse>(entity);
    }

    public async Task<IEnumerable<AttendanceResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<AttendanceResponse>>(entities);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(Attendance), id);

        await repository.DeleteAsync(id);
    }
}