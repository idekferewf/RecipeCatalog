using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCatalog.Data;
using RecipeCatalog.Model.Auth;

namespace RecipeCatalog.Pages.Account;

public class Register : PageModel
{
    private readonly ApplicationDbContext _context;

    public Register(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty] public required Model.Auth.Register Input { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        User? user = _context.Users.FirstOrDefault(u => u.Email == Input.Email);

        if (user == null)
        {
            bool isFirstUser = !_context.Users.Any();
            _context.Users.Add(new User
                { Email = Input.Email, Password = Input.Password, Role = isFirstUser ? "Admin" : "User" }
            );
            await _context.SaveChangesAsync();

            await Authenticate(Input.Email);
            return RedirectToPage("/Index");
        }

        ModelState.AddModelError(string.Empty, "Пользователь с данной электронной почтой уже зарегистрирован.");
        return Page();
    }

    private async Task Authenticate(string login)
    {
        var claims = new List<Claim> { new Claim(ClaimsIdentity.DefaultNameClaimType, login) };
        var identity = new ClaimsIdentity(claims, "ApplicationCookie");
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
    }
}