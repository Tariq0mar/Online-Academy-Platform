using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ILectureFileRepository : IRepository<LectureFile>
{
    Task<IEnumerable<LectureFile>> QueryAsync(LectureFileQuery query);
}