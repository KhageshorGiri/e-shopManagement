using eshop.Auth.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace eshop.Auth.Identity.ViewModels;

public class UserViewModel : ApplicationUser
{

}

public class RegisterUserViewMode
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    [DataType(DataType.Password)]
    [Compare("Password")]
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

public class ResetPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

    [Required]
    public string Code { get; set; }
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

public class ResetPasswordResponseViewModel
{
    public bool Succeeded { get; set; } = false;
    public IEnumerable<IdentityError> Errors;
}

public class ForgetPasswordResponseViewModel
{
    public string Code { get; set; }
    public bool Succeeded { get; set; } = false;
    public IEnumerable<IdentityError> Errors;
}