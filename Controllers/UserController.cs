using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Taller_HU4.Infrastructure;
using Taller_HU4.Interfaces;
using Taller_HU4.Models;

namespace Taller_HU4.Controllers;

public class UserController : Controller
{
    private readonly IUserRepository<User> _userRepository;
    private readonly IBookRepository<Book> _bookRepository;
    private readonly ILoanRepository<Loan> _loanRepository;
    
    public UserController(IUserRepository<User> userRepository, IBookRepository<Book> bookRepository, ILoanRepository<Loan> loanRepository)
    {
        _userRepository = userRepository;
        _bookRepository = bookRepository;
        _loanRepository = loanRepository;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userRepository.GetAllAsync();
        
        return View(users);
    }
    
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        try
        {
            if (ModelState.IsValid)
            {
                bool DNIExist = await _userRepository.DNIExistAsync(user.DocumentId);
                if(DNIExist)
                {
                    ModelState.AddModelError(string.Empty, "Document ID already exists");
                    return View(user);
                }
                await _userRepository.CreateAsync(user);
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }
        catch (Exception e)
        {
            TempData["Error"] = e.Message;
            throw;
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var user = await _userRepository.GetOneAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        try
        {
            var existingUser = await _userRepository.GetOneAsync(user.Id);
            if (existingUser == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(user);
            }

            await _userRepository.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating user: {ex.Message}");
            ModelState.AddModelError(string.Empty, "An error occurred while updating the user.");
            return View(user);
        }
    }


    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userRepository.GetOneAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        await _userRepository.DeleteAsync(user);
        return RedirectToAction(nameof(Index));
    }
}