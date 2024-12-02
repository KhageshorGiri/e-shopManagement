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
        services.AddScoped<IBlogCategoryService, BlogCategoryService>();
        services.AddScoped<IBlogSubCategoryService, BlogSubCategoryService>();
        services.AddScoped<IBlogService, BlogService>();

        // Data
        services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
        services.AddScoped<IBlogSubCategoryRepository, BlogSubCategoryRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();

        return services;
    }
}
