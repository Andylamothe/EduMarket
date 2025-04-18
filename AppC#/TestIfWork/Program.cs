using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.DataBase;
using Model.Entity.Utilisateur;

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
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated(); 
            Console.WriteLine("Base de données (re)créée.");

            InitializeData(db);

            DisplayData(db);

        }

        private static void InitializeData(DataBase db)
        {
            try
            {
                if (!db.Admins.Any())
                {
                    db.Admins.Add(new Admin
                    {
                        FirstName = "Alice",
                        LastName = "Dupont",
                        Email = "alice.dupont@example.com",
                        Phone = "0102030405",
                        Login = "alice.dupont",
                        Password = "1234"
                    });
                }

                if (!db.Teachers.Any())
                {
                    db.Teachers.Add(new Teacher
                    {
                        FirstName = "Bernard",
                        LastName = "Martin",
                        Email = "bernard.martin@example.com",
                        Phone = "0605040302",
                        Login = "bernard.martin",
                        Password = "1234"
                    });
                }

                if (!db.Students.Any())
                {
                    db.Students.Add(new Student
                    {
                        FirstName = "Claire",
                        LastName = "Durand",
                        Email = "claire.durand@example.com",
                        Phone = "0701020304",
                        Login = "claire.durand",
                        Password = "1234"
                    });
                }

                if (!db.Departements.Any())
                {
                    db.Departements.Add(new Departement
                    {
                        FirstName = "Informatique",
                        LastName = "Faculté",
                        Email = "contact@info.univ.fr",
                        Phone = "0808070707",
                        Login = "informatique",
                        Password = "1234"
                    });
                }

                db.SaveChanges();
                Console.WriteLine("Données insérées dans la base.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'initialisation des données : {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Détails de l'exception interne : {ex.InnerException.Message}");
                }
            }
        }

        private static void DisplayData(DataBase db)
        {
            var admins = db.Admins.ToList();
            foreach (var admin in admins)
            {
                Console.WriteLine($"Admin: {admin.FirstName} {admin.LastName}, Email: {admin.Email}");
            }

            var teachers = db.Teachers.ToList();
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"Teacher: {teacher.FirstName} {teacher.LastName}, Email: {teacher.Email}");
            }

            var students = db.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"Student: {student.FirstName} {student.LastName}, Email: {student.Email}");
            }

            var departements = db.Departements.ToList();
            foreach (var departement in departements)
            {
                Console.WriteLine($"Departement: {departement.FirstName} {departement.LastName}, Email: {departement.Email}");
            }
        }
    }
}

