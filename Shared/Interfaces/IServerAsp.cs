namespace Shared.Interfaces;

public interface IServerAsp<T>
{
    public Task<T> AddObject(T type);
    public Task<T> GetObject(string id);
    public Task<bool> UpdateObject(T type);
    public Task<bool> DeleteObject(string id);
    public Task<List<T>> GetAllObject();
}
