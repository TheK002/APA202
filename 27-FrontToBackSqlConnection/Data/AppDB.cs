using _27_FrontToBackSqlConnection.Models;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Data
{
    public class AppDB: DbContext
    {
        public AppDB(DbContextOptions<AppDB> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
    }
}
