using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCatalog.Data;
using RecipeCatalog.Model.Auth;

namespace RecipeCatalog.Pages.Account;

[Authorize]
public class ProfileModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public ProfileModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public required User CurrentUser { get; set; }

    public bool IsAdmin => User.IsInRole("Admin");

    public IActionResult OnGet(int id = 0)
    {
        User? user;
        if (id == 0)
        {
            var email = User.Identity?.Name;
            if (email == null)
            {
                return RedirectToPage("/Account/Login");
            }

            user = _context.Users.FirstOrDefault(u => u.Email == email);
        }
        else
        {
            user = _context.Users.FirstOrDefault(u => u.Id == id);
        }

        if (user == null)
        {
            return NotFound();
        }

        CurrentUser = user;

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        User? user = _context.Users.FirstOrDefault(u => u.Id == CurrentUser.Id);
        if (user == null)
        {
            return NotFound();
        }

        if (User.IsInRole("Admin"))
        {
            user.Role = CurrentUser.Role;
            _context.SaveChanges();
        }

        return RedirectToPage();
    }
}