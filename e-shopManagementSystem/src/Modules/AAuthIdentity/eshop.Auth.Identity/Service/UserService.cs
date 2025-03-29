using eshop.Auth.Identity.Entities;
using eshop.Auth.Identity.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace eshop.Auth.Identity.Service;
public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly IUserEmailStore<ApplicationUser> _emailStore;

    public UserService(UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IUserStore<ApplicationUser> userStore)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _userStore = userStore;
        _emailStore = GetEmailStore();
    }


    public async Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesListAsync(CancellationToken cancellationToken = default)
    {
        return (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    }

    public async Task<UserViewModel> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return new UserViewModel
        {
            Email = user?.Email
        };
    }

    public async Task<RegisterResponseViewModel> RegisterNewUserAsync(RegisterUserViewMode newUser, CancellationToken cancellationToken = default)
    {
        var response = new RegisterResponseViewModel();
        var user = CreateUser();

        await _userStore.SetUserNameAsync(user, newUser.Email, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, newUser.Email, CancellationToken.None);
        var result = await _userManager.CreateAsync(user, newUser.Password);

        if (result.Succeeded)
        {
            //assign admin role to user
            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            var userId = await _userManager.GetUserIdAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            
            response.UserId = userId;
            response.Code = code;

            if (_userManager.Options.SignIn.RequireConfirmedAccount)
            {
                response.RequireConfirmedAccount = true;
            }
            else
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                response.Succeeded = true;
            }
        }

        response.Errors = result.Errors;
        return response;
    }

    public async Task<LoginResponseViewModel> LoginAsync(LoginRequestViewModel loginRequest, CancellationToken cancellationToken = default)
    {
        var response = new LoginResponseViewModel();
        var result = await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, loginRequest.RememberMe, lockoutOnFailure: false);

        if(result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            var roles = await _userManager.GetRolesAsync(user);

            response.Succeeded = true;
            response.Roles = roles;
            response.RequiresTwoFactor = result.RequiresTwoFactor;
            response.IsLockedOut = result.IsLockedOut;
        }

        return response;
    }

    public async Task LogOutAsync(CancellationToken cancellationToken = default)
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<ResetPasswordResponseViewModel> ResetPasswordAsync(ResetPasswordViewModel input, CancellationToken cancellationToken = default)
    {
        var response = new ResetPasswordResponseViewModel();
        var user = await _userManager.FindByEmailAsync(input.Email);
        if(user == null)
        {
            response.Succeeded = false;
            return response;
        }
        var result = await _userManager.ResetPasswordAsync(user, input.Code, input.Password);
        if (result.Succeeded)
        {
            response.Succeeded = true;
        }
        response.Errors = result.Errors;
        return response;
    }

    public async Task<ForgetPasswordResponseViewModel> GeneratePasswordResetTokenAsync(string email)
    {
        var response = new ForgetPasswordResponseViewModel();
        var user = await _userManager.FindByEmailAsync(email);
        //TODO : Verify also is email is verified or not
        if (user == null)
        {
            response.Succeeded = false;
            return response;
        }
        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        response.Code = code;
        return response;
    }




    private ApplicationUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<ApplicationUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }

    private IUserEmailStore<ApplicationUser> GetEmailStore()
    {
        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<ApplicationUser>)_userStore;
    }

}
