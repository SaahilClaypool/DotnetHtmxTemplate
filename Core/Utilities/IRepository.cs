using System.Linq.Expressions;

namespace Core;

public interface IRepository<T>
    where T : IHasId
{
    public Task Insert(IEnumerable<T> items);
    public Task<ICollection<K>> Query<K>(
        Expression<Func<IQueryable<T>, IQueryable<K>>> query
    );
    public Task Delete(IEnumerable<T> items);
}
