using Microsoft.EntityFrameworkCore;
using Sysme.Data.Contexts;
using Sysme.Data.IRepositories;
using Sysme.Domain.Commons;
using System.Linq.Expressions;

namespace Sysme.Data.Repositories;

public class Repository<T> : IRepository<T> where T : AudiTable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<T> dbSet;

    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        dbSet = appDbContext.Set<T>();
    }
    public async Task CreateAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        await dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        entity.IsDelete = true;
    }

    public void Destroy(T entity)
    {
        dbSet.Remove(entity);
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isNoTracked = true, string[] includes = null)
    {
        IQueryable<T> query = expression is null ? dbSet.AsQueryable() : dbSet.Where(expression).AsQueryable();

        query = isNoTracked ? query.AsNoTracking() : query;

        if (includes is not null)
            foreach (var item in includes)
            {
                query = query.Include(item);
            }
        return query;
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null)
    {
        IQueryable<T> query = dbSet.AsQueryable();

        if (includes is not null)
            foreach (var item in includes)
            {
                query = query.Include(item);
            }

        var entity = await query.FirstOrDefaultAsync(expression);
        return entity;
    }

    public async Task SaveChanges()
    {
        await appDbContext.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        appDbContext.Entry(entity).State = EntityState.Modified;
    }
}
