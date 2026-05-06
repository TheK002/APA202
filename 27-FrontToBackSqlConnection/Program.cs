using _27_FrontToBackSqlConnection.Data;
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
                opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Task27DB;Trusted_Connection=True;TrustServerCertificate=True");
            });

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
