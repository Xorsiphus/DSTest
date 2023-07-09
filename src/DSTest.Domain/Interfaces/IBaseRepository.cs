using DSTest.Domain.Entities;

namespace DSTest.Domain.Interfaces;

public interface IBaseRepository<T> where T : class, IEntity
{
    Task Save(T entity);
    Task SaveAll(IEnumerable<T> entities);
    Task<IEnumerable<T>> Query(int take, int offset);
    Task<int> GetCount();
}