using CMgt.Application.DependencyConfiguration;
using CMgt.Infrastrucutre.Data;
using CMgt.Web;
using eshop.Auth.Identity;
using eshop.Auth.Identity.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SqlServerConnection") ?? 
    throw new InvalidOperationException("Connection string 'SqlServerConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(connectionString,
     dbCntxOpt => dbCntxOpt.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "Indentity")));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthModuleDependency();

builder.Services.AddServiceDIConfiguration();

var app = builder.Build();

// Db Seeding
app.Seed().Wait();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication()
    .UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapRazorPages();

app.Run();
