namespace Shared.Interfaces;

public interface IClient<T>
{
    public Task<T> AddObject(T type);
    public Task<T> GetObject(int id);
    public Task<bool> UpdateObject(T type);
    public Task<bool> DeleteObject(int id);
    public Task<List<T>> GetAllObject();
}
