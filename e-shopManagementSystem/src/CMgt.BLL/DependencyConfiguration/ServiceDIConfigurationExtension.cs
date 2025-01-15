using CMgt.Application.IServices;
using CMgt.Application.Services;
using CMgt.Domain.IRepositories;
using CMgt.Infrastrucutre.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CMgt.Application.DependencyConfiguration;

public static class ServiceDIConfigurationExtension
{
    public static IServiceCollection AddServiceDIConfiguration(this  IServiceCollection services)
    {

        // Service
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISubCategoryService, SubCategoryService>();
        services.AddScoped<IProdcutService, ProdcutService>();
        services.AddScoped<IOrderService, OrderService>();

        // Data
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}
