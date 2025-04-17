using System.IO; // pour Path
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model;

namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var relativePath = Path.Combine("db", "test.db");
            Directory.CreateDirectory(Path.GetDirectoryName(relativePath)!);
            var connectionString = $"Data Source={relativePath}";

            var serviceProvider = new ServiceCollection()
                .AddDbContext<DataBase>(options =>
                {
                    options.UseSqlite(connectionString);
                    options.UseLazyLoadingProxies();
                })
                .BuildServiceProvider();

            using var db = serviceProvider.GetRequiredService<DataBase>();
            db.Database.EnsureDeleted(); // Drop si tu veux toujours repartir de 0
            db.Database.EnsureCreated(); // Création
            Console.WriteLine("Base de données (re)créée.");
        }
    }
}
