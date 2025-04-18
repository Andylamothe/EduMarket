using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Model.Entity.Utilisateur;
using Model.repository;

namespace Model.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Departement>().ToTable("Departements");
            modelBuilder.Entity<Teacher>().ToTable("Teachers");
            modelBuilder.Entity<Student>().ToTable("Students");

            ApplyReductionConstraint<Admin>(modelBuilder);
            ApplyReductionConstraint<Teacher>(modelBuilder);
            ApplyReductionConstraint<Student>(modelBuilder);
            ApplyReductionConstraint<Departement>(modelBuilder);
        }

        [Obsolete]
        private void ApplyReductionConstraint<TEntity>(ModelBuilder modelBuilder) where TEntity : class
        {
            modelBuilder.Entity<TEntity>()
                .HasCheckConstraint($"CK_{typeof(TEntity).Name}_Reduction", "[Reduction] >= 0 AND [Reduction] <= 100");
        }
    }
    public class DataBaseUsage
    {
        public static void InitializeData(IServiceProvider provider)
        {
            AddIfEmpty(provider, new Admin
            {
                FirstName = "Alice",
                LastName = "Dupont",
                Email = "alice.dupont@example.com",
                Phone = "0102030405",
                Login = "alice.dupont",
                Password = "1234"
            });

            AddIfEmpty(provider, new Teacher
            {
                FirstName = "Bernard",
                LastName = "Martin",
                Email = "bernard.martin@example.com",
                Phone = "0605040302",
                Login = "bernard.martin",
                Password = "1234"
            });

            AddIfEmpty(provider, new Student
            {
                FirstName = "Claire",
                LastName = "Durand",
                Email = "claire.durand@example.com",
                Phone = "0701020304",
                Login = "claire.durand",
                Password = "1234"
            });

            AddIfEmpty(provider, new Departement
            {
                FirstName = "Informatique",
                LastName = "Faculté",
                Email = "contact@info.univ.fr",
                Phone = "0808070707",
                Login = "informatique",
                Password = "1234"
            });
        }

        private static void AddIfEmpty<TEntity>(IServiceProvider provider, TEntity entity) where TEntity : class
        {
            var repository = provider.GetRequiredService<IRepository<TEntity>>();
            if (!repository.GetAllAsync().Result.Any())
            {
                repository.AddAsync(entity).Wait();
                Console.WriteLine($"{typeof(TEntity).Name} ajouté avec succès.");
            }
        }

        public static void DisplayData<TEntity>(IServiceProvider provider) where TEntity : class
        {
            var repository = provider.GetRequiredService<IRepository<TEntity>>();
            var entities = repository.GetAllAsync().Result;

            foreach (var entity in entities)
            {
                Console.WriteLine(entity?.ToString());
            }
        }
    }
}
