using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eshop.Auth.Identity.ViewModels;
public class RegisterUserViewMode
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
}


public class LoginRequestViewModel 
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}


public class RegisterResponseViewModel
{
    public string UserId { get; set; }
    public string Code { get; set; }
    public bool Succeeded { get; set; } = false;
    public bool RequireConfirmedAccount { get; set; }
    public IEnumerable<IdentityError> Errors;
}

public class LoginResponseViewModel
{
    public string UserId { get; set; }
    public bool Succeeded { get; set; } = false;
    public bool RequiresTwoFactor { get; set; }
    public bool IsLockedOut { get; set; }
    public IList<string> Roles { get; set; }
    public IEnumerable<IdentityError> Errors;
}
