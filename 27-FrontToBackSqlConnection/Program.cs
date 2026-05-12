using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace _27_FrontToBackSqlConnection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDB>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
            });

            //bu
            //ilder.Services.AddSingleton<EmailService>();

            builder.Services.AddScoped<IEmailService, TestService>();

            //builder.Services.AddTransient<EmailService>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
