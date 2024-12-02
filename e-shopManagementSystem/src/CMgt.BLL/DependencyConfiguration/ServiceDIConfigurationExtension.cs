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
        services.AddScoped<CategoryService, CategoryService>();
        services.AddScoped<SubCategoryService, SubCategoryService>();

        // Data
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();

        return services;
    }
}
