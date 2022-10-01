
namespace Termo.Core.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int? id);
        Task<TResult> GetAsync<TResult>(int? id);
        Task<List<T>> GetAllAsync();
        Task<List<TResult>> GetAllAsync<TResult>();
        Task<T> AddAsync(T entity);
        Task<TResult> AddAsync<TSource, TResult>(TSource source);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task<bool> Exists(int id);
    }
}
