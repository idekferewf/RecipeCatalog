using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeCatalog.Data;
using RecipeCatalog.Model.Auth;

namespace RecipeCatalog.Pages.Account;

[Authorize(Roles = "Admin")]
public class ProfilesModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public ProfilesModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<User> Users { get; set; } = new();

    public void OnGet()
    {
        Users = _context.Users.ToList();
    }
}