using eshop.Auth.Identity.ViewModels;
using Microsoft.AspNetCore.Authentication;

namespace eshop.Auth.Identity.Service;
public interface IUserService
{
    Task<UserViewModel> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesListAsync(CancellationToken cancellationToken = default);
    Task<RegisterResponseViewModel> RegisterNewUserAsync(RegisterUserViewMode user, CancellationToken cancellationToken = default);
    Task<LoginResponseViewModel> LoginAsync(LoginRequestViewModel loginRequest, CancellationToken cancellationToken = default);
    Task LogOutAsync(CancellationToken cancellationToken = default);
    Task<ResetPasswordResponseViewModel> ResetPasswordAsync(ResetPasswordViewModel input, CancellationToken cancellationToken = default);
    Task<ForgetPasswordResponseViewModel> GeneratePasswordResetTokenAsync(string email);
}
