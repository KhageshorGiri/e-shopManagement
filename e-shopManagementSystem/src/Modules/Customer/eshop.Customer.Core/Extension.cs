using eshop.Customer.Core.Service;
using eshop.Customer.Core.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eshop.Customer.Core;
public static class Extension
{
    public static IServiceCollection AddCustomerModuleDiExtension(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        return services;
    }
}
