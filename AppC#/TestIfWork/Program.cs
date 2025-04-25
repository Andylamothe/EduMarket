using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.DataBase;
using Model.repository;
using Model.table;

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
                .AddDbContext<DataBaseContext>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var provider = scope.ServiceProvider;
                var db = provider.GetRequiredService<DataBaseContext>();

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Console.WriteLine("Base de données (re)créée.");

                DataBaseUsage.InitializeData(provider);

                Console.WriteLine("ADMIN:");
                DataBaseUsage.DisplayData<Admin>(provider);

                Console.WriteLine("TEACHER:");
                DataBaseUsage.DisplayData<Teacher>(provider);

                Console.WriteLine("STUDENT:");
                DataBaseUsage.DisplayData<Student>(provider);

                Console.WriteLine("DEPARTEMENT:");
                DataBaseUsage.DisplayData<Departement>(provider);
            }
        }
    }
}

