using Microsoft.EntityFrameworkCore;
using Taller_HU4.Infrastructure;
using Taller_HU4.Interfaces;
using Taller_HU4.Models;

namespace Taller_HU4.Repository;

public class UserRepository : IUserRepository<User>
{
    private readonly AppDbContext _context;
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<bool> DNIExistAsync(string DNI)
    {
        return  await _context.Users.AnyAsync(u => u.DocumentId == DNI);
    }

    public async Task<User?> GetOneAsync(User entity)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == entity.Id);
    }
    
    public async Task<User> CreateAsync(User entity)
    {
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<User> UpdateAsync(User entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<User> DeleteAsync(User entity)
    {

        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}