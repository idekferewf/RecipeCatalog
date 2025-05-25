using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Model.Auth;

public class Register
{
    [Required(ErrorMessage = "Необходимо указать электронную почту.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Необходимо указать пароль.")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Необходимо повторно указать пароль.")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
    public required string ConfirmPassword { get; set; }
}