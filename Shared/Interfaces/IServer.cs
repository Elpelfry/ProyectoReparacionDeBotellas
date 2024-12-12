using System.Linq.Expressions;

namespace Shared.Interfaces;

public interface IServer<T>
{
    public Task<T> AddObject(T type);
    public Task<T> GetObject(int id);
    public Task<bool> UpdateObject(T type);
    public Task<bool> DeleteObject(int id);
    public Task<List<T>> GetAllObject();
    public Task<List<T>> GetObjectByCondition(Expression<Func<T, bool>> expression);
}
