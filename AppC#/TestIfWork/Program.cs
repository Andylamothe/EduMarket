using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model;
using Model.Entity.Utilisateur;

namespace App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<DataBase>(options =>
                    options.UseSqlite("Data Source=AppCSharp.db"))
                .BuildServiceProvider();

            // Créer la base de données ou appliquer les migrations
            using var db = serviceProvider.GetRequiredService<DataBase>();
            db.Database.EnsureCreated();
            Console.WriteLine("Base de données créée ou déjà existante.");
            db.Database.Migrate();
            Console.WriteLine("Migrations appliquées avec succès.");

            // Ajouter un admin si la table est vide
            if (!db.Admins.Any())
            {
                db.Admins.Add(new Admin { FirstName = "Admin", LastName = "Test", Reduction = 10 });
                db.SaveChanges();
                Console.WriteLine("Admin ajouté.");
            }

            // Afficher les admins
            var admins = db.Admins.ToList();
            foreach (var admin in admins)
            {
                Console.WriteLine($"Admin: {admin.FirstName} {admin.LastName}, Reduction: {admin.Reduction}");
            }
        }
    }
}
