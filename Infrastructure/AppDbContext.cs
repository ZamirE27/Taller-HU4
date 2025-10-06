using Microsoft.EntityFrameworkCore;
using Taller_HU4.Models;

namespace Taller_HU4.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.DocumentId)
            .IsUnique();
        modelBuilder.Entity<Book>()
            .HasIndex(b => b.Code)
            .IsUnique();
    }

}

