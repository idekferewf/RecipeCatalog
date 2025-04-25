using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Model.Auth;

public class Register
{
    [Required(ErrorMessage = "Необходимо указать электронную почту.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Необходимо указать пароль.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
    public string ConfirmPassword { get; set; }
}
