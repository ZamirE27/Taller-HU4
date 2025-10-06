using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Taller_HU4.Interfaces;
using Taller_HU4.Models;

namespace Taller_HU4.Controllers;

public class BookController : Controller
{
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<Loan> _loanRepository;
    
    public BookController(IRepository<User> Userepository, IRepository<Book> bookRepository, IRepository<Loan> loanRepository)
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
        var users = await _userRepository.GetAllAsync();
        ViewBag.Users = new SelectList(users, "Id", "Name");
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(Book book)
    {
        if (book.UserId == 0)
        {
            ModelState.AddModelError("User Id", "You should select a user");
        }
        if (ModelState.IsValid)
        {
            await _bookRepository.CreateAsync(book);
            return RedirectToAction(nameof(Index));
        }
        var users = await _userRepository.GetAllAsync();
        ViewBag.Users = new SelectList(users, "Id", "Name");
    
        return View(book);
    }
}