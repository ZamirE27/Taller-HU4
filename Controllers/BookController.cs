using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taller_HU4.Infrastructure;
using Taller_HU4.Interfaces;
using Taller_HU4.Models;

namespace Taller_HU4.Controllers;

public class BookController : Controller
{
    private readonly AppDbContext _context;
    private readonly IUserRepository<User> _userRepository;
    private readonly IBookRepository<Book> _bookRepository;
    private readonly ILoanRepository<Loan> _loanRepository;
    
    public BookController(IUserRepository<User> Userepository, IBookRepository<Book> bookRepository, ILoanRepository<Loan> loanRepository)
    {
        _userRepository = Userepository;
        _bookRepository = bookRepository;
        _loanRepository = loanRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var books = await _bookRepository.GetAllAsync();
        return View(books);
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        try
        {

            if (ModelState.IsValid)
            {
                bool codeExist = await _bookRepository.CodeExistAsync(book.Code);
                if (codeExist)
                {
                    ModelState.AddModelError(string.Empty, "Code already exist");
                    return View(book);
                }
                await _bookRepository.CreateAsync(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = ex.Message;
            return RedirectToAction(nameof(Index));
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(Book book)
    {
        if (book.Id == null)
        {
            ModelState.AddModelError(string.Empty, "User not found");
            return View(book);
        }
        await _bookRepository.DeleteAsync(book);
        return RedirectToAction(nameof(Index));
    }
}