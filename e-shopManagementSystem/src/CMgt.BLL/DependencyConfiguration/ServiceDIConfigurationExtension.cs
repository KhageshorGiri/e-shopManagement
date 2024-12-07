using CMgt.BLL.IServices;
using CMgt.BLL.Services;
using CMgt.DAL.IRepositories;
using CMgt.DAL.IRepositoriesl;
using CMgt.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CMgt.BLL.DependencyConfiguration;

public static class ServiceDIConfigurationExtension
{
    public static IServiceCollection AddServiceDIConfiguration(this  IServiceCollection services)
    {

        // Service
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ISubCategoryService, SubCategoryService>();
        services.AddScoped<IProdcutService, ProdcutService>();

        // Data
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
