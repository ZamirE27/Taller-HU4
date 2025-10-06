namespace Taller_HU4.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DocumentId { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Loan> Loans { get; set; } = new List<Loan>();
    
    public User() {}
    public User(string name, string documentId, string email, string phoneNumber)
    {
        Name = name;
        DocumentId = documentId;
        Email = email;
        PhoneNumber = phoneNumber;
    }
} 