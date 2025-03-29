
using Azure.Core;
using eshop.Auth.Identity.DbContext;
using eshop.Auth.Identity.Entities;
using eshop.Auth.Identity.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using System.Text.Encodings.Web;

namespace eshop.Auth.Identity.Service;
internal class UserService : IUserService
{
    private readonly IdentityDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IUserStore<ApplicationUser> _userStore;
    private readonly IUserEmailStore<ApplicationUser> _emailStore;

    public UserService(IdentityDbContext context,
         UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager,
          IUserStore<ApplicationUser> userStore)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _userStore = userStore;
        _emailStore = GetEmailStore();
    }

    public async Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesListAsync(CancellationToken cancellationToken = default)
    {
        return (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    }

    public async Task<RregisterResponseViewModel> RegisterNewUserAsync(UserViewMode newUser, CancellationToken cancellationToken = default)
    {
        var response = new RregisterResponseViewModel();
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
