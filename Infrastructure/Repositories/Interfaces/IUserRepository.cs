using Taller_HU4.Models;

namespace Taller_HU4.Interfaces;

public interface IUserRepository<T> where T : User
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> DNIExistAsync( string  DNI );
    Task<T> GetOneAsync(T entity);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}