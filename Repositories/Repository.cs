using Microsoft.EntityFrameworkCore;
using Taller_HU4.Infrastructure;
using Taller_HU4.Interfaces;
using Taller_HU4.Models;

namespace Taller_HU4.Repository;

public class Repository : IRepository<User>
{
    private readonly AppDbContext _context;
    public Repository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetOneAsync(User entity)
    {
        if (entity == null)
        {
            return null;
        }
        return await _context.Users.FindAsync(entity.Id);
    }
    
    public async Task<User> CreateAsync(User entity)
    {

        try
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Creating new user: {e.Message}");
            throw;
        }
        
    }

    public async Task<User> UpdateAsync(User entity)
    {
        if (entity == null)
        {
            return null;
        }
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<User> DeleteAsync(User entity)
    {
        if (entity == null)
        {
            return null;
        }

        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}