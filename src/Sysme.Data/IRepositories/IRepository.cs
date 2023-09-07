using Sysme.Domain.Commons;
using System.Linq.Expressions;

namespace Sysme.Data.IRepositories;

public interface IRepository<T> where T : AudiTable
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Destroy(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null);
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isNoTracked = true, string[] includes = null);
    Task SaveChanges();
}

