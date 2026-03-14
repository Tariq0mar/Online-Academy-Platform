using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ILectureRepository : IRepository<Lecture>
{
    Task<IEnumerable<Lecture>> QueryAsync(LectureQuery query);
}