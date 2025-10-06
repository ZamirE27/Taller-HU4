using Microsoft.EntityFrameworkCore;
using Taller_HU4.Infrastructure;
using Taller_HU4.Interfaces;
using Taller_HU4.Models;

namespace Taller_HU4.Repository;

public class BookRepository : IRepository<Book>
{
    private readonly AppDbContext _context;
    public BookRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var books = await _context.Books
            .Include(b => b.User)
            .ToListAsync();
        return await _context.Books.ToListAsync();
    }

    public async Task<Book> GetOneAsync(Book entity)
    {
        if (entity == null)
        {
            return null;
        }
        return await _context.Books.FindAsync(entity.Id);
    }
    
    public async Task<Book> CreateAsync(Book entity)
    {
        try
        {
            _context.Books.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error Creating new Book: {e.Message}");
            throw;
        }
    }

    public async Task<Book> UpdateAsync(Book entity)
    {
        if (entity == null)
        {
            return null;
        }
        _context.Books.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Book> DeleteAsync(Book entity)
    {
        if (entity == null)
        {
            return null;
        }

        _context.Books.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}