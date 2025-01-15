using CMgt.Domain.Entities;
using CMgt.Infrastrucutre.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CMgt.Web;

public static class DbSeed
{

    public static async Task Seed(this WebApplication app)
    {
        try
        {
            using (var serviceProvider = app.Services.CreateScope())
            {
                IServiceProvider provider = serviceProvider.ServiceProvider;
                ApplicationDbContext context = provider.GetRequiredService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                UserManager<User> userManager = provider.GetRequiredService<UserManager<User>>();
                RoleManager<IdentityRole<int>> roleManager = provider.GetRequiredService<RoleManager<IdentityRole<int>>>();

                //Seed roles
                await SeedRole(roleManager);

                //Seed admin user
                if (!await context.Users.AnyAsync())
                {
                    User user = new User
                    {
                        UserName = "admin@test.com",
                        Email = "admin@test.com"
                    };

                    //create user
                    var userResult = await userManager.CreateAsync(user, "Admin@123");

                    //assign admin role to user
                    var roleResult = await userManager.AddToRoleAsync(user, "Admin");
                }

              
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    //role creation code
    private static async Task SeedRole(RoleManager<IdentityRole<int>> roleManager)
    {
        if (!await roleManager.Roles.AnyAsync(x => x.Name == "Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole<int> { Name = "Admin", NormalizedName = "Admin" });
        }
        if (!await roleManager.Roles.AnyAsync(x => x.Name == "User"))
        {
            await roleManager.CreateAsync(new IdentityRole<int> { Name = "User", NormalizedName = "User" });
        }
    }
}
