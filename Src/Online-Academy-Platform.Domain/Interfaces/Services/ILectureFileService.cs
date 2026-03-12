using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface ILectureFileService: IService<LectureFile>
{
    Task<LectureFile> QueryAsync(LectureFileQuery query);
}