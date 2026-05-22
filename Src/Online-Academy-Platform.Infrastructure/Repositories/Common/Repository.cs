using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Infrastructure.Persistence;

namespace Online_Academy_Platform.Infrastructure.Repositories.Common;

public abstract class Repository<T>(ApplicationDbContext context) : IRepository<T>
    where T : class
{
    protected ApplicationDbContext Context { get; } = context;
    protected DbSet<T> DbSet { get; } = context.Set<T>();

    public virtual async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T?> GetByIdAsync(int id) =>
        await DbSet.FindAsync(id);

    public virtual async Task<IEnumerable<T>> GetAllAsync() =>
        await DbSet.ToListAsync();

    public virtual async Task<bool> ExistsAsync(int id) =>
        await DbSet.AnyAsync(e => EF.Property<int>(e, "Id") == id);

    public virtual async Task UpdateAsync(T entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
        {
            return;
        }

        DbSet.Remove(entity);
        await Context.SaveChangesAsync();
    }
}
