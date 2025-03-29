using eshop.Auth.Identity.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace eshop.Auth.Identity.Service;
public interface IUserService
{
    Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesListAsync(CancellationToken cancellationToken = default);
    Task<RegisterResponseViewModel> RegisterNewUserAsync(RegisterUserViewMode user, CancellationToken cancellationToken = default);

    // Login
    Task<LoginResponseViewModel> LoginAsync(LoginRequestViewModel loginRequest, CancellationToken cancellationToken = default);

    // Logout

    // Retset Password

    // Forget Passwrod
}
