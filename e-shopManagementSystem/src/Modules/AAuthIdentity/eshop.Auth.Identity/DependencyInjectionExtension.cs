using eshop.Auth.Identity.Service;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Auth.Identity;
public static class DependencyInjectionExtension
{
    public static void AddAuthModuleDependency(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
    }
}
