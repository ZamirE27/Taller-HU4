using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Taller_HU4.Infrastructure;
using Taller_HU4.Interfaces;
using Taller_HU4.Models;

namespace Taller_HU4.Repository;

public class BookRepository : IBookRepository<Book>
{
    private readonly AppDbContext _context;
    public BookRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books
            .ToListAsync();
    }

    public async Task<bool> CodeExistAsync(string code)
    {
        return  await _context.Books.AnyAsync(b => b.Code == code);
    }

    public async Task<Book?> GetOneAsync(int id)
    {
        return await _context.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);
    }
    
    public async Task<Book> CreateAsync(Book entity)
    {
        _context.Books.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Book> UpdateAsync(Book entity)
    {
        _context.Books.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Book> DeleteAsync(Book entity)
    {

        _context.Books.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}