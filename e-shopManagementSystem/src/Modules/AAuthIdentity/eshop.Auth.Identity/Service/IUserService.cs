using eshop.Auth.Identity.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace eshop.Auth.Identity.Service;
public interface IUserService
{
    Task<IList<AuthenticationScheme>> GetExternalAuthenticationSchemesListAsync(CancellationToken cancellationToken = default);
    Task<RregisterResponseViewModel> RegisterNewUserAsync(UserViewMode user, CancellationToken cancellationToken = default);

    // Login

    // Logout

    // Retset Password

    // Forget Passwrod
}
