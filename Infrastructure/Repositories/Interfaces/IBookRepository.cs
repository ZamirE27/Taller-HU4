using Taller_HU4.Models;

namespace Taller_HU4.Interfaces;

public interface IBookRepository<T> where T : Book
{
    Task<bool> CodeExistAsync( string  code );
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetOneAsync(T entity);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}