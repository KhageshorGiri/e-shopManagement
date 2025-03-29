using eshop.Auth.Identity.DbContext;
using eshop.Auth.Identity.Entities;
using eshop.Auth.Identity.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Auth.Identity;
public static class DependencyInjectionExtension
{
    public static IServiceCollection AddAuthModuleDependency(this IServiceCollection services)
    {

        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<AuthDbContext>();

        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
