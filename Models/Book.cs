namespace Taller_HU4.Models;

public class Book
{
    public int Id { get; set; }
    public string Tittle {get; set;}
    public string Author {get; set;}
    public string Code {get; set;}
    public int Available {get; set;}
    
    public int UserId {get; set;}
    public User? User {get; set;}
    
    public List<Loan> Loans { get; set; } = new List<Loan>();
    public Book() {}
    public Book(string tittle, string author, string code, int available,  int userId)
    {
        Tittle = tittle;
        Author = author;
        Code = code;
        Available = available;
        UserId = userId;
    }
}