using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller_HU4.Infrastructure;
using Taller_HU4.Interfaces;
using Taller_HU4.Models;

namespace Taller_HU4.Controllers;

public class UserController : Controller
{
    private readonly IRepository<User> Repository;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<Loan> _loanRepository;
    
    public UserController(IRepository<User> repository, IRepository<Book> bookRepository, IRepository<Loan> loanRepository)
    {
        Repository = repository;
        _bookRepository = bookRepository;
        _loanRepository = loanRepository;
    }

    public async Task<IActionResult> Index()
    {
        var users = await Repository.GetAllAsync();
        
        return View(users);
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var books = await _bookRepository.GetAllAsync();
        ViewBag.Books = books;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        if (ModelState.IsValid)
        {
            await Repository.CreateAsync(user);
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }
}