using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace Core;

public class MemoryRepository<T> : IRepository<T>
    where T : IHasId
{
    public ConcurrentDictionary<int, T> _items = new();

    public Task Delete(IEnumerable<T> items)
    {
        foreach (var i in items)
            _items.Remove(i.Id, out _);
        return Task.CompletedTask;
    }

    public Task Insert(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            _items[item.Id] = item;
        }
        return Task.CompletedTask;
    }

    public Task<ICollection<K>> Query<K>(
        Expression<Func<IQueryable<T>, IQueryable<K>>> query
    )
    {
        var result = query
            .Compile()
            .Invoke(_items.Values.AsQueryable())
            .ToList();
        return Task.FromResult(result as ICollection<K>);
    }
}
