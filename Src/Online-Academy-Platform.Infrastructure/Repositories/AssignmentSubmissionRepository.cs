using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class AssignmentSubmissionRepository(ApplicationDbContext context)
    : QueryableRepository<AssignmentSubmission, AssignmentSubmissionQuery>(context), IAssignmentSubmissionRepository
{
    protected override IQueryable<AssignmentSubmission> ApplyQuery(IQueryable<AssignmentSubmission> query, AssignmentSubmissionQuery queryParams) =>
        AssignmentSubmissionQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(AssignmentSubmissionQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(AssignmentSubmissionQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<AssignmentSubmission?> GetByAssignmentAndUserAsync(int assignmentId, int userId) =>
        await DbSet.FirstOrDefaultAsync(s => s.AssignmentId == assignmentId && s.UserId == userId);

    public async Task<bool> ExistsByAssignmentAndUserAsync(int assignmentId, int userId) =>
        await DbSet.AnyAsync(s => s.AssignmentId == assignmentId && s.UserId == userId);

    public async Task<IEnumerable<AssignmentSubmission>> GetByAssignmentIdAsync(int assignmentId) =>
        await DbSet.Where(s => s.AssignmentId == assignmentId).ToListAsync();

    public async Task<IEnumerable<AssignmentSubmission>> GetByUserIdAsync(int userId) =>
        await DbSet.Where(s => s.UserId == userId).ToListAsync();

    public async Task<bool> UpdateGradeAsync(int submissionId, int grade, string? feedback, SubmissionStatus status)
    {
        var submission = await GetByIdAsync(submissionId);
        if (submission is null)
        {
            return false;
        }

        submission.Grade = grade;
        submission.Feedback = feedback;
        submission.Status = status;
        await UpdateAsync(submission);
        return true;
    }
}
