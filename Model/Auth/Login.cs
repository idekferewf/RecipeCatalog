using System.ComponentModel.DataAnnotations;

namespace RecipeCatalog.Model.Auth;

public class Login
{
    [Required(ErrorMessage = "Необходимо указать электронную почту.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Необходимо указать пароль.")]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
